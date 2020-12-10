. (Join-Path -Path ".\tools" -ChildPath ".\Invoke-AuthorityConfig-Api.fun.ps1")

function Get-Auth-Clients(
    [Parameter(Mandatory = $true)][string]$Authority,
    [Parameter(Mandatory = $false)][switch]$Details,
    [Parameter(Mandatory = $false)][string]$ClientId,
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $param = @{
        authority = $Authority
    }
    $data = (Invoke-AuthorityConfig-Api -method "GetConfig" -param $param -AuthorityConfigAddress $AuthorityConfigAddress) 
    if ($data) {
        $clients = $data.clients
        if ($ClientId) {
            $clients = ($clients | Where-Object { $_.clientId -eq $ClientId})
        }
        if ($Details) {
            $clients | ForEach-Object {
                Write-Host ($_ | ConvertTo-Json)
                Write-Host "***"
            }
        } else {
            $clients | ForEach-Object {
                Write-Host $_.clientId
            }
        }
    } else {
        Write-Host "Failed..."
    }
}
