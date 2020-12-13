. (Join-Path -Path ".\tools" -ChildPath ".\Invoke-AuthorityConfig-Api.fun.ps1")

<#
.SYNOPSIS
    Provide configuration information for clients that uses the authroity server to authorize users and get tokens.
.EXAMPLE
    PS> Get-Auth-Clients -Authority <authorityconfig>
    Lists clientId of all clients configured
.EXAMPLE
    PS> Get-Auth-Clients -Authority <authorityconfig> -Details
    Lists configuration details of all clients
.EXAMPLE
    PS> Get-Auth-Clients -Authority <authorityconfig> -Details -ClientId <id>
    Lists configuration details of client with given id
#>
function Get-Auth-Clients(
    [Parameter(Mandatory = $true)][string]$Authority,
    [Parameter(Mandatory = $false)][switch]$Details,
    [Parameter(Mandatory = $false)][string]$ClientId,
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $param = @{
        authority = $Authority
    }
    $data = (Invoke-AuthorityConfig-Api -method "GetClients" -param $param -AuthorityConfigAddress $AuthorityConfigAddress) 
    if ($data) {
        if ($ClientId) {
            $data = ($data | Where-Object { $_.clientId -eq $ClientId})
        }
        if ($Details) {
            $data | ForEach-Object {
                Write-Host ($_ | ConvertTo-Json)
                Write-Host "***"
            }
        } else {
            $data | ForEach-Object {
                Write-Host $_.clientId
            }
        }
    } else {
        Write-Host "Failed..."
    }
}
