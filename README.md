# RobotSelection
Robot Selector API 

**Purpose**: Allows A user to get the closest `Robot` to a `Load`

**Run:**
Start the API
```
$ dotnet run
```
Call endpoint using host:port info from run command output.

*using http in example in case local certificate is an issue, commented out app.UseHttpsRedirection function in Program.cs for this behavior*

```
curl -v -X POST   http://localhost:5044/SelectRobot   -H 'Content-Type:application/json'   -d '{
    "loadId": "23",
    "x": 99,
    "y": 66
}'
```
**Endpoints**:

`POST /selectrobot`:
Calls `GET /robots` endpoint and determines the distance from the `Robot` to the provided `Load` based on `x`,`y` coordinates
Payload:
```
{
  "loadId": string,
  "x": int,
  "y": int
}
```

**Future Development Ideas:**
1. Store robots that have been selected/queued to allow for selection based on availability
2. Add Load limits on selected robots: "this robot can be queued up for n number of loads"
3. Add number of current Loads with list of load IDs 
4. Only Select Robots with load availability comparing load limit to current loads
5. Endpoint for getting a selected robot by LoadId for tracking a loads progress "load is n Load in robots queue"
6. add Robot Id to stored Load once a robot is selected...
7. all of this assumes creating a database with these relationships available in collections/tables wheter it be NOSQL or SQL depending on the necessity of joins etc
