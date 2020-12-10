function Set-Auth-Client(
    [Parameter(Mandatory = $true)][string]$Authority,
    [Parameter(Mandatory = $true)][string]$ClientId,
    [Parameter(Mandatory = $false)][string]$ScopesToAdd,
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $param = @{
        authority = $Authority
        clientId = $ClientId
        scopesToAdd = $ScopesToAdd
    }
    Invoke-AuthorityConfig-Api -method "SetClient" -param $param -AuthorityConfigAddress $AuthorityConfigAddress
}