###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-20
# AppVeyor Script to Deploy Project to Azure VM
###############################################################

# Build and Deploy WCF Service (AppVeyor config ignores RestaurantDemoSite Project in Solution)
msbuild Restaurant\Restaurant.sln /p:DeployOnBuild=true /p:PublishProfile=AzureVM `
/p:Configuration=AppVeyor /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD

# Build and Deploy Website
msbuild Restaurant\RestaurantDemoSite\website.publishproj /p:DeployOnBuild=true /p:PublishProfile=AzureVM `
/p:Configuration=Release /p:AllowUntrustedCertificate=true /p:Password=$env:AZURE_VM_PASSWORD