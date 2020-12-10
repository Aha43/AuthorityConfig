. (Join-Path -Path ".\tools" -ChildPath ".\Invoke-AuthorityConfig-Api.fun.ps1")

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
