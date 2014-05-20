###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-19
# Script to Deploy Projects to Local Machine in Debug Mode
###############################################################

# Change for your local environment
$gitRepositories = "$env:USERPROFILE\Documents\git_repos"

# WCF Service
cd "$gitRepositories\cross-domain-wcf-rest\Restaurant\RestaurantWcfService"
msbuild RestaurantWcfService.csproj /p:DeployOnBuild=true /p:PublishProfile=LocalMachine `
	 /p:VisualStudioVersion=12.0 /p:Configuration=Debug

# Website
cd "$gitRepositories\cross-domain-wcf-rest\Restaurant\RestaurantDemoSite"
msbuild website.publishproj /p:DeployOnBuild=true /p:PublishProfile=LocalMachine `
	 /p:VisualStudioVersion=12.0 /p:Configuration=Debug