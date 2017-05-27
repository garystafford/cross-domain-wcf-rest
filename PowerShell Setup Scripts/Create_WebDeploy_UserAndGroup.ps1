########################################################################
# Author: Gary A. Stafford
# Revised: 2014-06-02
# Create new local non-admin User and Group for Web Deploy
# Reference - Flags: http://msdn.microsoft.com/en-us/library/aa772300%28v=vs.85%29.aspx
########################################################################

########################################################################
# Main variables (Change these!)
[string]$userName  = "DEPLOYMENT_USERNAME"   # mjones
[string]$fullName  = "DEPLOYMENT_FULL_NAME"  # Mike Jones
[string]$password  = "DEPLOYMENT_PASSWORD"   # pa$$w0RD!
[string]$groupName = "DEPLOYMENT_GROUP"      # Development
########################################################################

# Create new local user account
[ADSI]$server="WinNT://$Env:COMPUTERNAME"
$newUser = $server.Create("User", $userName)
$newUser.SetPassword($password)

# $newUser | Get-Member # List members like below
$newUser.Put("FullName", "$fullName")
$newUser.Put("Description", "$fullName User Account")

# Assign flags to user
[int]$ADS_UF_PASSWD_CANT_CHANGE = 64
[int]$ADS_UF_DONT_EXPIRE_PASSWD = 65536
[int]$COMBINED_FLAG_VALUE       = 65600

$flags = $newUser.UserFlags.value -bor $COMBINED_FLAG_VALUE
$newUser.put("userFlags", $flags)
$newUser.SetInfo()
Write-Host "*** New User '$userName' created."

# Create new local group
$newGroup=$server.Create("Group", $groupName)
$newGroup.Put("Description","$groupName Group")
$newGroup.SetInfo()
Write-Host "*** New Group '$groupName' created."

# Assign user to group
[string]$serverPath = $server.Path
$group = [ADSI]"$serverPath/$groupName, group"
$group.Add("$serverPath/$userName, user")
Write-Host "*** User '$userName' assigned to Group '$groupName'."