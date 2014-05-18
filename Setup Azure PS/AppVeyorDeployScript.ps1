###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-15
# AppVeyor Script to Deploy Project to Azure VM
###############################################################

cd "C:\projects\cross-domain-wcf-rest\Restaurant\RestaurantDemoSite"
msbuild website.publishproj /p:DeployOnBuild=true /p:PublishProfile=AzureVM /p:VisualStudioVersion=12.0 `
	/p:Configuration=Release /t:WebPublish /p:AllowUntrustedCertificate=true /p:Password=%AZURE_VM_PSW%

cd "C:\projects\cross-domain-wcf-rest\Restaurant\RestaurantWcfService"
msbuild RestaurantWcfService.csproj /p:DeployOnBuild=true /p:PublishProfile=AzureVM /p:VisualStudioVersion=12.0 `
	/p:Configuration=Release /t:WebPublish /p:AllowUntrustedCertificate=true /p:Password=%AZURE_VM_PSW%
