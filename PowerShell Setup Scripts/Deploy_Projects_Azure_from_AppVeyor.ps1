###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-23
# Deploy Projects to Azure VM from AppVeyor
###############################################################

# Deploy WCF service
# (AppVeyor config ignores website Project in Solution)
msbuild Restaurant\Restaurant.sln `
  /p:DeployOnBuild=true /p:PublishProfile=AzureVM /p:Configuration=AppVeyor `
  /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD `
  /verbosity:minimal /nologo

# Deploy website
msbuild Restaurant\RestaurantDemoSite\website.publishproj `
  /p:DeployOnBuild=true /p:PublishProfile=AzureVM /p:Configuration=Release `
  /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD `
  /verbosity:minimal /nologo

Write-Host "*** Solution deployments complete."
