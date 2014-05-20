[![Build status](https://ci.appveyor.com/api/projects/status/r1k65tywqe314gti)](https://ci.appveyor.com/project/garystafford/cross-domain-wcf-rest)

### Consuming Cross-Domain WCF REST Services with jQuery using JSONP

Updated project for Blog Post: [Consuming Cross-Domain WCF REST Services with jQuery using JSONP](http://programmaticponderings.wordpress.com/2011/09/25/consuming-cross-domain-wcf-rest-services-with-jquery-using-jsonp/)

#### Installation and Configuration
*  Clone GitHub Repository
  *  Run command: ```git clone https://github.com/garystafford/cross-domain-wcf-rest```
*  Set-up Environment Variables
  *  Edit (3) environment variables values in script: Create_EnvironmentVariables.ps1 
  *  Run PS script: Create_EnvironmentVariables.ps1
*  Set-up Local Environment
  *  Run PS script: Create_OrderDirectory.ps1
  *  Run PS script: Create_WebDirectories.ps1
  *  Run PS script: Configure_IIS.ps1
  *  Edit ```$gitRepositories``` variable in PS script: Deploy_Projects_Local.ps1
*  Deploy Projects Locally
  *  Run PS script: Deploy_Projects_Local.ps1

#### Other Scripts
*  Deploy Projects from AppVeyor to Azure VM
  *  Run PS script: Deploy_Projects_AppVeyor.ps1
