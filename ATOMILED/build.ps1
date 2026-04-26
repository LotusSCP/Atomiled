#! pwsh

param (
    [Switch]$BuildNuGet
)

$Projects = @(
    'Atomiled.Loader',
    'Atomiled.API',
    'Atomiled.Permissions',
    'Atomiled.Events',
    'Atomiled.CreditTags',
    'Atomiled.Example',
    'Atomiled.CustomItems',
    'Atomiled.CustomRoles'
)

function Execute {
    param (
        [string]$Cmd
    )

    foreach ($Project in $Projects) {
        Invoke-Expression ([string]::Join(' ', $Cmd, $Project, $args))
        CheckLastOperationStatus
    }
}

function CheckLastOperationStatus {
    if ($? -eq $false) {
        Exit 1
    }
}

function GetSolutionVersion {
    [XML]$PropsFile = Get-Content Atomiled.props
    $Version = $PropsFile.Project.PropertyGroup[2].Version
    $Version = $Version.'#text'.Trim()
    return $Version
}

# Restore projects
Execute 'dotnet restore'
# Build projects
Execute 'dotnet build' '-c release'
# Build a NuGet package if needed
if ($BuildNuGet) {
    $Version = GetSolutionVersion
    $Year = [System.DateTime]::Now.ToString('yyyy')

    Write-Host "Generating NuGet package for version $Version"

    nuget pack Atomiled/Atomiled.nuspec -Version $Version -Properties Year=$Year
}

