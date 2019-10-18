# usage
# .\build.ps1 1.0.0 {apikey}
$version=$args[0]
$key=$args[1]
$projName="EntityFramewrokCoreExtension"
dotnet pack -p:PackageVersion=$version --include-symbols -o "packages" "./$($projName)/$($projName).csproj"
dotnet nuget push "./packages/$($projName).$($version).symbols.nupkg" -k $key -s "https://www.nuget.org"

