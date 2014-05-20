###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-15
# AppVeyor Script to Deploy Project to Azure VM
###############################################################

# Build and Deploy WCF Service
msbuild Restaurant\RestaurantWcfService\RestaurantWcfService.csproj /p:DeployOnBuild=true /p:PublishProfile=AzureVM `
/p:VisualStudioVersion=12.0 /p:Configuration=AppVeyor /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD

# Build and Deploy Website
msbuild Restaurant\RestaurantDemoSite\website.publishproj /p:DeployOnBuild=true /p:PublishProfile=AzureVM `
/p:VisualStudioVersion=12.0 /p:Configuration=Release /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD