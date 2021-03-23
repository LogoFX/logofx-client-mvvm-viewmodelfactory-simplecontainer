cd ../../src
dotnet build LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer.sln -c Release
dotnet test LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer.sln -c Release
cd ../devops/publish