# FirebaseBlazorAuth - example 
![Blazor](https://img.shields.io/badge/blazor-%235C2D91.svg?style=for-the-badge&logo=blazor&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![C#](https://img.shields.io/badge/.NET-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/Firebase-FFCA28.svg?style=for-the-badge&logo=Firebase&logoColor=black)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

Demonstration code of basic Firebase authenticaion in Blazor WASM using MudBlazor
## Functions
With this example, you can:
- Register
- Login
- See how to lock components off via `AuthorizeView`

There is also some example validation to handle callbacks from Firebase when a error is thrown. 
![Image1](https://i.imgur.com/LpMxkn4.png)

## Install

To run this project, you will need to add the following environment variables in `wwwroot/appsettings.json`

`FirebaseApiKey`

`FirebaseAuthDomain`

![Image2](https://i.imgur.com/wEUEPgu.png)


## Packages

- firebaseauthentication.net 4.0.1
- microsoft.aspnetcore.components.webassembly 7.0.1
- microsoft.aspnetcore.components.webassembly.authentication 7.0.1
- microsoft.aspnetcore.components.webassembly.devserver 7.0.1
- mudblazor 6.4.1


## Mudblazor

This can easily be removed and turned back to stock blazor with boostrap 4. Just follow the mudblazor installation guide backwards. 
## Acknowledgements

 - [rtssn's auth sample](https://github.com/rtssn/BlazorWebAssemblyApp-Auth-Sample)


## Build state

[![Build](https://github.com/PSCourtney/FirebaseBlazorAuth/actions/workflows/dotnet.yml/badge.svg)](https://github.com/PSCourtney/FirebaseBlazorAuth/actions/workflows/dotnet.yml)
