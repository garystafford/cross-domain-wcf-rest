[![Build status](https://ci.appveyor.com/api/projects/status/r1k65tywqe314gti)](https://ci.appveyor.com/project/garystafford/cross-domain-wcf-rest)

### Consuming Cross-Domain WCF REST Services with jQuery using JSONP

Updated project for Blog Post: [Consuming Cross-Domain WCF REST Services with jQuery using JSONP](http://programmaticponderings.wordpress.com/2011/09/25/consuming-cross-domain-wcf-rest-services-with-jquery-using-jsonp/)

#### Installation and Configuration
*  Clone GitHub Repository
  *  Run command: ```git clone --branch=rev2014 https://github.com/garystafford/cross-domain-wcf-rest```
*  Create Environment Variables
  *  Edit (3) environment variables values Create_EnvironmentVariables.ps1 
  *  Run PS script: Create_EnvironmentVariables.ps1
  *  NOTE: New environment variables won't show up in current shell. You must close and re-open the shell.
*  Set-up Local Environment
  *  Run PS script: Create_OrderDirectory.ps1
  *  Run PS script: Create_WebDirectories.ps1
  *  Run PS script: Configure_IIS.ps1
  *  Edit ```$gitRepositories``` variable value in Deploy_Projects_Local.ps1
*  Deploy Projects Locally
  *  Run PS script: Deploy_Projects_Local.ps1
*  MSBuild
  *  Make sure you are calling VS2013's new MSBuild from command line. Use 'where msbuild' to confirm.
  *  MSBuild moved with VS2013. Seems to vary by machine. Do a file search...
  *  If not setup, add path to PATH environment variable (i.e. 'C:\Program Files (x86)\MSBuild\12.0\Bin')
  *  Good post about VS2013 MSBuild: http://timrayburn.net/blog/visual-studio-2013-and-msbuild/
#### Other Scripts
*  Deploy Projects from AppVeyor to Azure VM
  *  Run PS script: Deploy_Projects_AppVeyor.ps1
