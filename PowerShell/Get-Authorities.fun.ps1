function Get-Authorities(
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $data = (Invoke-AuthorityConfig-Api -method "GetAuthorities" -AuthorityConfigAddress $AuthorityConfigAddress) 
    if ($data) {
        $data | ConvertTo-Json
    } else {
        Write-Host "Failed..."
    }
}