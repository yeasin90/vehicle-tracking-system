# Vehicle Tracking System
Download and unzip the folder. Go to **vehicle-tracking-system\src** folder and open the solution file. Clean and rebuild the solution.

## Overview:
There are two back end projects under this solution:
1. VTS.AuthServer (IdentityServer)
2. VTS.Backend (Backend api server)

Swagger UI has been integrated with Backend api sever. To work with Vehicle api, a JWT access token is required. From the swagger UI, check **Authorization** endpoint to generate a JWT token (check endpoint description for available credentials). Once you received the token, set the token value by pressing **Authorize** button in swagger UI. Now, you can now play with vehicle apis from swagger.

**NB:** Make sure VTS.AuthServer (IdentityServer) is up and running upfront. Otherwise, token will not be generated/validated.

## Pre-requisites:
- Visual Studio 2019 or higher
- .net core 3.1 or higher
- Google api key ([how to create](https://developers.google.com/maps/documentation/maps-static/get-api-key))

## Run projects using Docker
+ Make sure Docker Desktop with Linux support is installed
+ Upate your Google api key
  * Navigate to **vehicle-tracking-system\src** folder
  * Open **docker-compose.yml** file
  * Find **GoogleMapSettings__ApiKey** section and place your Google api key there
+ From command line (Gitbash or PowerShell), navigate to **vehicle-tracking-system\src** folder
+ Execute commad: 
  * > docker-compose build
+ Execute below commad:
  * > docker-compose up

IdentityServer and Backend server should be created. To verify, hit below urls in the browser:
```sh
IdentityServer: http://localhost:5000
Backend server: http://localhost:5001
```

## Run projects from Visual Studio
+ Start IdentityServer:
    * Right click on **VTS.IdentityServer** project
    * Select **Debug->Start New Instance**
+ Upate your Google api key
  * Open **appsettings.Development.json** from **VTS.Backend.Api** project
  * Find **GoogleMapSettings** section and place your Google api key there
+ Start Backend server project
    * Right click on **VTS.Backend.Api** project
    * Select Debug->Start New Instance

Both IdentityServer and Backend server should be launched automatically in the browser.
