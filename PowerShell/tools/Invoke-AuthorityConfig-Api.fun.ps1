function Invoke-AuthorityConfig-Api(
    [Parameter(Mandatory = $true)][string]$method,
    [Parameter(Mandatory = $true)][Object]$param,
    [Parameter(Mandatory = $true)][string]$AuthorityConfigAddress
) {
    try {
        $json = $param | ConvertTo-Json
        $uri = ($AuthorityConfigAddress + "api/" + $method)
        $response = (Invoke-RestMethod -Method 'Post' -Uri $uri -Body $json -ContentType "application/json")
        if (-not $response.success) {
            Write-Error $response.ErrorMessage
            return $null
        }
        return $response.data
    } catch {
        Write-Error $_.Exception.Message
        return $null
    }
}