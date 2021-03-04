# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of projects
$projects = (  
    # modules/saas-toolkit
    "src/Abdul.Abp.SaasToolkit.Application.Contracts",
    "src/Abdul.Abp.SaasToolkit.Application",
    "src/Abdul.Abp.SaasToolkit.Domain",
    "src/Abdul.Abp.SaasToolkit.Domain.Shared",
    "src/Abdul.Abp.SaasToolkit.EntityFrameworkCore",
    "src/Abdul.Abp.SaasToolkit.HttpApi.Client",
    "src/Abdul.Abp.SaasToolkit.HttpApi",
    "src/Abdul.Abp.SaasToolkit.Web"
)
