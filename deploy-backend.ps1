# deploy-backend.ps1

# Variables
$resourceGroup = "recursopostgressmod4"
$appServicePlan = "firstback-plan"
$webAppName = "firstback-api"
$location = "eastus"
$publishFolder = "./publish"
$zipFile = "backend.zip"

# Cadena de conexión PostgreSQL (reemplaza si usas otra)
$connectionString = "Host=firstbackdb-postgres.postgres.database.azure.com;Port=5432;Database=NodoDB;Username=postgres;Password=Eafit12345;Ssl Mode=Require;Trust Server Certificate=true;"

# JWT Keys
$jwtKey = "37301188386789253435490698376144"
$jwtIssuer = "ProductApi"
$jwtAudience = "ProductApiUsers"

# Verifica si estás logueado
Write-Host "🔐 Verificando sesión en Azure..."
az account show > $null 2>&1
if ($LASTEXITCODE -ne 0) {
    az login
}

# Compilar proyecto
Write-Host "⚙️ Publicando en modo Release..."
dotnet publish -c Release -o $publishFolder

# Comprimir en ZIP
Write-Host "📦 Comprimiendo archivos..."
if (Test-Path $zipFile) { Remove-Item $zipFile -Force }
Compress-Archive -Path "$publishFolder/*" -DestinationPath $zipFile

# Crear App Service Plan si no existe
Write-Host "🧱 Verificando App Service Plan..."
$planExists = az appservice plan show --name $appServicePlan --resource-group $resourceGroup --query "name" -o tsv 2>$null
if (-not $planExists) {
    az appservice plan create --name $appServicePlan --resource-group $resourceGroup --sku F1 --location $location
}

# Crear Web App si no existe
Write-Host "🌐 Verificando Web App..."
$webAppExists = az webapp show --name $webAppName --resource-group $resourceGroup --query "name" -o tsv 2>$null
if (-not $webAppExists) {
    az webapp create --resource-group $resourceGroup --plan $appServicePlan --name $webAppName --runtime $runtime --deployment-local-git
}

# Configurar cadena de conexión
Write-Host "🔗 Configurando cadena de conexión..."
az webapp config connection-string set `
  --name $webAppName `
  --resource-group $resourceGroup `
  --settings DefaultConnection="$connectionString" `
  --connection-string-type PostgreSQL


# Configurar variables de entorno (JWT y Azure Blob Storage)
Write-Host "🛡️ Configurando JWT y Azure Blob Storage..."
az webapp config appsettings set `
  --name $webAppName `
  --resource-group $resourceGroup `
  --settings `
  "Jwt__Key=$jwtKey" `
  "Jwt__Issuer=$jwtIssuer" `
  "Jwt__Audience=$jwtAudience" `
  "AzureBlob__ConnectionString=$env:AZURE_BLOB_CONNECTION_STRING" `
  "AzureBlob__ContainerName=uploads"

# Activar logs
Write-Host "📝 Activando logs..."
az webapp log config `
  --name $webAppName `
  --resource-group $resourceGroup `
  --application-logging filesystem `
  --level information

# Desplegar
Write-Host "🚀 Desplegando aplicación..."
az webapp deploy `
  --resource-group $resourceGroup `
  --name $webAppName `
  --src-path $zipFile

Write-Host "✅ Despliegue completo. Abre: https://$webAppName.azurewebsites.net"
