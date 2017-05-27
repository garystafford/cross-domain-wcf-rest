###############################################################
# Author: Gary A. Stafford
# Revised: 2017-05-26
# Deploy Projects to Azure VM from Local development workstation
###############################################################

###############################################################
# Main variables (Change these!)
[string]$projectLocation = "C:\Users\gary.stafford\Source\Repos\cross-domain-wcf-rest\Restaurant"
###############################################################

# Deploy WCF service
msbuild "$projectLocation\Restaurant.sln" `
  /p:DeployOnBuild=true /p:PublishProfile=AzureVM /p:Configuration=AppVeyor `
  /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD `
  /verbosity:minimal /nologo

# Deploy website
msbuild "$projectLocation\RestaurantDemoSite\website.publishproj" `
  /p:DeployOnBuild=true /p:PublishProfile=AzureVM /p:Configuration=AppVeyor `
  /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD `
  /verbosity:minimal /nologo

Write-Host "*** Solution deployments complete."
	
# Pause script before closing to check output - only for manual execution!
$host.enternestedprompt()