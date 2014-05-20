########################################################################
# Author: Gary A. Stafford
# Revised: 2014-05-19
# Script creates required Web Publish Profile environment variables
# for Azure VM. Two used in profile. One in msbuild command.
########################################################################

# http://technet.microsoft.com/en-us/library/ff730964.aspx

[Environment]::SetEnvironmentVariable("AZURE_VM_HOSTNAME", "gstafford.cloudapp.net", "User")
[Environment]::SetEnvironmentVariable("AZURE_VM_USERNAME", "MSDepSvcUser", "User")
[Environment]::SetEnvironmentVariable("AZURE_VM_PASSWORD", "WebDeploy123", "User")

Get-ChildItem Env: | Where name -Like "AZURE_VM_*"
