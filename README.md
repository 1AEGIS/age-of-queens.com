# age-of-queens.com
This .NET Core Web application is written for Age of Queens. Age of Queens is a community and a safe space for women who play Age of Empires to cultivate an environment that connects women to other women and encourage more to pick up the game.

## Requirements
* .NET Core 6.0 SDK
* Python 3.0 (For one script file)

## Build
* Building is easily possible in VSCode. I proved a launch.json and tasks.json file.
* If you want to build it yourself
```
dotnet publish "ageofqueenscom.csproj" -c Release -p:EnvironmentName=Production
```
* Fill appsettings.json or use environment variables. For development I recommend user secrets.

## Run
```
dotnet ageofqueens.dll --urls=https://localhost:5001/
```

## Deploy
Currently I use GitHub Actions to deploy this webapplication on my webserver. 

## Authors
* DasEvoli (Vinzenz Wetzel)

## License
This project is licensed under the Apache License 2.0