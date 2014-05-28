########################################################################
# Author: Gary A. Stafford
# Revised: 2014-05-28
# Create New local User and Group for Non-Admin Web Deploy
########################################################################

# flags: http://msdn.microsoft.com/en-us/library/aa772300%28v=vs.85%29.aspx

# Create new local user account
[ADSI]$server="WinNT://WIN-V45N5QASH6U"
$MSDepSvcUser=$server.Create("User","MSDepSvcUser")
$MSDepSvcUser.SetPassword("W3bD3p10y")
$MSDepSvcUser.Put("Description","MSDepSvcUser Local Account")

# Assign flags to user
[int]$ADS_UF_PASSWD_CANT_CHANGE = 64
[int]$ADS_UF_DONT_EXPIRE_PASSWD  = 65536
[int]$COMBINED_FLAG_VALUE = 65600

$flag = $MSDepSvcUser.UserFlags.value -bor $COMBO_FLAGS
$MSDepSvcUser.put("userFlags",$flag)
$MSDepSvcUser.SetInfo()
Write-Host "*** User Created."

# Create new local group
$MSDepSvcGroup=$server.Create("Group","MSDepSvcGroup")
$MSDepSvcGroup.Put("Description","MSDepSvcGroup Local Group")
$MSDepSvcGroup.SetInfo()
Write-Host "*** Group Created."

# Assign user to group
[string]$serverPath = $server.Path
[string]$userName = $MSDepSvcUser.Name
[string]$groupName = $MSDepSvcGroup.Name
$group = [ADSI]"$serverPath/$groupName,group"
$group.Add("$serverPath/$userName,user")
Write-Host "*** User assigned to Group."
