. (Join-Path -Path ".\tools" -ChildPath ".\Invoke-AuthorityConfig-Api.fun.ps1")

<#
.SYNOPSIS
    Gets complete configuration of an authority
.EXAMPLE
    PS> Get-Auth-Config -Authority <authority>
    Gets complete configuration of named authority
#>
function Get-Auth-Config(
    [Parameter(Mandatory = $true)][string]$Authority,
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $param = @{
        authority = $Authority
    }
    $data = (Invoke-AuthorityConfig-Api -method "GetConfig" -param $param -AuthorityConfigAddress $AuthorityConfigAddress) 
    if ($data) {
        $data | ConvertTo-Json
    } else {
        Write-Host "Failed..."
    }
}
