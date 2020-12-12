function Invoke-AuthorityConfig-Api(
    [Parameter(Mandatory = $true)][string]$method,
    [Parameter(Mandatory = $false)][Object]$param,
    [Parameter(Mandatory = $true)][string]$AuthorityConfigAddress
) {
    try {
        $uri = ($AuthorityConfigAddress + "api/" + $method)
        $response = $null
        if ($param) {
            $json = $param | ConvertTo-Json
            $response = (Invoke-RestMethod -Method 'Post' -Uri $uri -Body $json -ContentType "application/json")
        } else {
            $response = (Invoke-RestMethod -Method 'Post' -Uri $uri)
        }
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