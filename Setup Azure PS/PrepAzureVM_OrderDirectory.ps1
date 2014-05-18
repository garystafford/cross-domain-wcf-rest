###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-14
# Prep Azure VM for 'cross-domain-wcf-rest' project deployment
# Create directory and security settings for restaurant orders
###############################################################

#The possible values for Rights are 
# ListDirectory, ReadData, WriteData 
# CreateFiles, CreateDirectories, AppendData 
# ReadExtendedAttributes, WriteExtendedAttributes, Traverse
# ExecuteFile, DeleteSubdirectoriesAndFiles, ReadAttributes 
# WriteAttributes, Write, Delete 
# ReadPermissions, Read, ReadAndExecute 
# Modify, ChangePermissions, TakeOwnership
# Synchronize, FullControl


# Create new restaurant orders directory
$newDirectory = "c:\RestaurantOrders"

if (-not (Test-Path $newDirectory)){
    New-Item -Type directory -Path $newDirectory
}

$acl = Get-Acl $newDirectory
$ar = New-Object System.Security.AccessControl.FileSystemAccessRule(
    "INTERACTIVE","Modify","ContainerInherit, ObjectInherit", "None", "Allow")
$acl.SetAccessRule($ar)
Set-Acl $newDirectory $acl