# Vehicle Tracking System

### Pre-requisites:
- Visual Studio 2019 or higher
- .net core 3.1 or higher
- Google api key

### How to run the project
+ Unzip the folder
+ Clean and rebuild the solutions
+ First, Start IdentityServer:
    * Right click on **VTS.IdentityServer** project
    * Select Debug->Start New Instance
+ Add your Google api key
  * Create a Goole api key. To know how to create one, click [here](https://developers.google.com/maps/documentation/maps-static/get-api-key).
  * In **VTS.Backend.Api** project, P=place your api key in **appsettings.Development.json** under **GoogleMapSettings** section
+ Start Backend project
    * Right click on **VTS.Backend.Api** project
    * Select Debug->Start New Instance

### Sequence diagram


```mermaid
sequenceDiagram
Alice ->> Bob: Hello Bob, how are you?
Bob-->>John: How about you John?
Bob--x Alice: I am good thanks!
Bob-x John: I am good thanks!
Note right of John: Bob thinks a long<br/>long time, so long<br/>that the text does<br/>not fit on a row.

Bob-->Alice: Checking with John...
Alice->John: Yes... John, how are you?
```
