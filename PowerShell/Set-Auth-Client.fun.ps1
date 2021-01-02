function Set-Auth-Client(
    [Parameter(Mandatory = $false)][switch]$DryRun,
    [Parameter(Mandatory = $true)][string]$Authority,
    [Parameter(Mandatory = $false)][switch]$Create,
    [Parameter(Mandatory = $true)][string]$ClientId,
    [Parameter(Mandatory = $false)][string]$Name,
    [Parameter(Mandatory = $false)][string]$Desc,
    [Parameter(Mandatory = $false)][string]$Uri,
    [Parameter(Mandatory = $false)][string]$LogoUri,
    [Parameter(Mandatory = $false)][bool]$Enabled,
    [Parameter(Mandatory = $false)][switch]$RequireClientSecret,
    [Parameter(Mandatory = $false)][bool]$RequireConsent,
    [Parameter(Mandatory = $false)][bool]$AllowRememberConsent,
    [Parameter(Mandatory = $false)][string]$GrantsToAdd,
    [Parameter(Mandatory = $false)][string]$GrantsToRemove,
    [Parameter(Mandatory = $false)][string]$ClientSecret,
    [Parameter(Mandatory = $false)][string]$ScopesToAdd,
    [Parameter(Mandatory = $false)][string]$ScopesToRemove,
    [string]$AuthorityConfigAddress = $Env:AuthorityConfigAddress
) {
    $param = @{
        dryRun = $DryRun.IsPresent
        authority = $Authority
        createIfDoesNotExists = $Create.IsPresent
        clientId = $ClientId
        clientName = $Name
        description = $Desc
        clientUri = $Uri
        logoUri = $LogoUri
        enabled = $Enabled
        requireClientSecret = $RequireClientSecret.IsPresent
        requireConsent = $RequireConsent
        allowRememberConsent = $AllowRememberConsent
        grantTypesToAdd = $GrantsToAdd
        grantTypesToRemove = $GrantsToRemove
        clientSecret = $ClientSecret
        scopesToAdd = $ScopesToAdd
        scopesToRemove = $ScopesToRemove
    }
    $data = Invoke-AuthorityConfig-Api -method "SetClient" -param $param -AuthorityConfigAddress $AuthorityConfigAddress
    
    Write-Host
    if ($data.Created) {
        Write-Host 'Client did not exists, was created'
    }
    if ($data.Secret) {
        Write-Host ('Client password in plain: ' + $data.Secret)
    }
    if ($data.DryRun) {
        Write-Host 'Was a dry run, configuration database not updated'
    }
    if ($data) {
        $data.Client | ConvertTo-Json
    }
}