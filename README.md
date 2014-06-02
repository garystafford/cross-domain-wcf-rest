[![Build status](https://ci.appveyor.com/api/projects/status/r1k65tywqe314gti)](https://ci.appveyor.com/project/garystafford/cross-domain-wcf-rest)

### Cloud-based Continuous Integration and Delivery for .NET Development

New Blog Post:[Cloud-based Continuous Integration and Deployment for .NET Development](http://wp.me/p1RD28-1aL)

Original Blog Post: [Consuming Cross-Domain WCF REST Services with jQuery using JSONP](http://wp.me/p1RD28-4)

#### Local Installation and Configuration
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
  *  Edit ```$gitRepositories``` variable value in Build_Deploy_Projects_Local.ps1
*  Deploy Projects Locally
  *  Run PS script: Build_Deploy_Projects_Local.ps1
*  VS2013 MSBuild Path
  *  MSBuild moved with VS2013. Make sure you are calling VS2013's version of MSBuild from command line.
  *  Use 'where msbuild' from command line to confirm MSBuild's current location.
  *  If not set-up correctly, replace or add msbuild executable path to PATH environment variable (i.e. 'C:\Program Files (x86)\MSBuild\12.0\Bin')
  *  Good post about VS2013 MSBuild: http://timrayburn.net/blog/visual-studio-2013-and-msbuild/

#### Setting up AppVeyor
  *  Settings -> Environment -> Environment variables -> Add AZURE_VM_HOSTNAME, AZURE_VM_USERNAME, and AZURE_VM_PASSWORD
  *  Settings -> Build -> Build Script -> PS -> '. "PowerShell Setup Scripts\Build_Projects_AppVeyor.ps1"'
  *  Settings -> Test -> Before test script -> PS -> '. "PowerShell Setup Scripts\Create_OrderDirectory.ps1"'
  *  Settings -> Deployment -> Deployment Script -> PS -> '. "PowerShell Setup Scripts\Deploy_Projects_AppVeyor.ps1"'
  *  Note the period (.) in above PowerShell commands.

#### Setting up Azure VM (locally on VM)
  *  Create new Web Deploy non-admin user and group, run 'powershell Create_WebDeploy_UserAndGroup.ps1'
  *  Configure both projects in IIS to allow web deployments from the above user, run 'powershell Configure_WebDeployUserInIIS.ps1'

#### Optional - Setting Up Host Server Behind Proxy
  *  If on network with proxy server, change the primary environment variables in Configure_Env_Git_Run3x.bat.
  *  Run Configure_Env_Git_Run3x.bat 3x's (because of nested variables). 

#### Previews
<p>
    <a href='https://github.com/garystafford/cross-domain-wcf-rest/blob/rev2014/images/VS2013ViewSolution.PNG?raw=true'><img src='https://github.com/garystafford/cross-domain-wcf-rest/blob/rev2014/images/VS2013ViewSolution_preview.PNG?raw=true'></a>
</p>
<p>
    <a href='https://github.com/garystafford/cross-domain-wcf-rest/blob/rev2014/images/AppVeyorLastBuild.PNG?raw=true'><img src='https://github.com/garystafford/cross-domain-wcf-rest/blob/rev2014/images/AppVeyorLastBuild_preview.PNG?raw=true'></a>
</p>
<p>
    <a href='https://github.com/garystafford/cross-domain-wcf-rest/blob/rev2014/images/RevisedIU.PNG?raw=true'><img src='https://github.com/garystafford/cross-domain-wcf-rest/blob/rev2014/images/RevisedIU.PNG?raw=true'></a>
</p>
