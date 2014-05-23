########################################################################
# Author: Gary A. Stafford
# Revised: 2014-05-23
# Create (3) environment variables
# (2) used in profile, (1) in msbuild commands
########################################################################

# http://technet.microsoft.com/en-us/library/ff730964.aspx

# Create environment variables
[Environment]::SetEnvironmentVariable("AZURE_VM_HOSTNAME", `
	"{YOUR HOSTNAME HERE}", "User")

[Environment]::SetEnvironmentVariable("AZURE_VM_USERNAME", `
	"{YOUR USERNME HERE}", "User")

[Environment]::SetEnvironmentVariable("AZURE_VM_PASSWORD", `
	"{YOUR PASSWORD HERE}", "User")

# Following command will not return values first time.
# You must restart the PS shell to use the new variable.
Get-ChildItem Env: | Where name -Like "AZURE_VM_*"
