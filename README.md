# Vehicle Tracking System
Download and unzip the folder. Go to **vehicle-tracking-system\src** folder and open the solution file. Clean and rebuild the solution.

## Overview:
There are two back end projects under this solution:
1. VTS.AuthServer 
2. VTS.Backend 

**VTS.AuthServer** is the IdentityServer for Authentication/Authorization. **VTS.Backend** is the backend server where required REST api endpoints are exposed.

## Pre-requisites:
- Visual Studio 2019 or higher
- .net core 3.1 or higher
- Google api key ([how to create](https://developers.google.com/maps/documentation/maps-static/get-api-key))

## Run solution using Docker
+ Make sure Docker Desktop with Linux support is installed in your local machine.
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

## Run solution from Visual Studio
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

## Workflow
When you hit the backend server url in browser (http://localhost:5001), you will get SwaggerUI for api playground. There are two api sections:
1. Authorization (for getting token with username/password)
2. Vehicle (endpoints for vehicle related tasks)

To play with Vehicle endpoints, you must have an JWT access token. To get an authenticated JWT token, try the endpoint from Authorization (description of the endpoint contains credentials to use). Once you received the token, set the token value by pressing **Authorize** button from SwaggerUI. Vehicle api's should be authorized afterwards and you can start play with the Vehicle endpoints.

**NB:** Make sure VTS.AuthServer (IdentityServer) is up and running upfront. Otherwise, token will not be generated/validated.


