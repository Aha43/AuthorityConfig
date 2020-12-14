<#
.SYNOPSIS
    Adds API that clients can get access (token) to.
.EXAMPLE
    PS> Add-Auth-Api -Authority <authorityconfig> -Name <apiname>
    Adds API with same name and display name
.EXAMPLE
    PS> Add-Auth-Api -Authority <authorityconfig> -Name <apiname> -DisplayName <displayname>
    Adds API with given name and display name
#>
function Add-Auth-Api-Scope(
    [Parameter(Mandatory = $true)][string]$Authority,
    [Parameter(Mandatory = $true)][string]$Name,
    [Parameter(Mandatory = $false)][string]$DisplayName,
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $param = @{
        authority = $Authority
        name = $Name
        displayName = $DisplayName
    }
    Invoke-AuthorityConfig-Api -method "AddApiScope" -param $param -AuthorityConfigAddress $AuthorityConfigAddress 
}
