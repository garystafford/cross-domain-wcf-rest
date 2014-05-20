﻿########################################################################
# Author: Gary A. Stafford
# Revised: 2014-05-19
# Script creates required Web Publish Profile environment variables
# for Azure VM. Two used in profile, one in msbuild command.
########################################################################

# http://technet.microsoft.com/en-us/library/ff730964.aspx

[Environment]::SetEnvironmentVariable("AZURE_VM_HOSTNAME", "gstafford.cloudapp.net", "User")
[Environment]::SetEnvironmentVariable("AZURE_VM_USERNAME", "MSDepSvcUser", "User")
[Environment]::SetEnvironmentVariable("AZURE_VM_PASSWORD", "WebDeploy123", "User")

# Following command will not return values first time.
# You must restart the PS shell to see the new variable.
Get-ChildItem Env: | Where name -Like "AZURE_VM_*"
