# SPOT - VehicleTrackingAPI

Backend -> ASP.NET Core 5.0
MySQL -> MySQL 8.0.22

## Package Dependencies
- Pomelo.EntityFrameworkCore.MySql v3.2.4
- Microsoft.EntityFrameworkCore.Design v3.1.10
- Microsoft.EntityFrameworkCore.Tools v3.1.10
- Microsoft.AspNetCore.Identity v2.2.0
- Microsoft.AspNetCore.Identity.EntityFrameworkCore v2.2.0
- Microsoft.Extensions.Configuration.FileExtensions v5.0.0
- Microsoft.Extensions.Configuration.Json v5.0.0
- Microsoft.Extensions.Identity.Core v5.0.1


## Run Locally
Can use docker-compose up to build and run both ASP.NET and MySQL
```
docker-compose up --build
```
I've already seed some data in C# Code while startup

And use docker-compose down to take down both service
```
docker-compose down
```

## Seed Data
### User
Username = admin
Password = secretpassword
### Vehicle
There are 4 vehicles assigned to the database with different data.

## Example

**Login**
> GET:localhost:5000/api/user/login
```
RequestBody
{
    "username": "admin",
    "password": "secretpassword"
}

```

**Vehicle Register**
> POST:localhost:5000/api/vehicle/
```
RequestBody
{
    "name":"E"
}
ResponseBody
{
    "result": "esXq6SPJ_r14cX3jSbOOvF9bBbSiMEpd1gq4gzKL0VA="
}
```

**Vehicle Update status**
> PUT:localhost:5000/api/vehicle/
```
RequestBody
{
    "code": "esXq6SPJ_r14cX3jSbOOvF9bBbSiMEpd1gq4gzKL0VA=",
    "Time": 1608788133665,
    "latitude": "13.822811",
    "longitude": "100.474439",
    "sensors": [
        {
            "name": "fuel",
            "value": "50"
        }
    ]
}
ResponseBody
{
    "result": true
}
```

**Get Vehicles**
> GET:localhost:5000/api/vehicle/?offset=0&limit=20
```
RequestQuery
{
    offset: 0 //default
    limit: 20 //default
}
ResponseBody
{
    "vehicles": [
        {
            "id": 1,
            "name": "A"
        },
        {
            "id": 2,
            "name": "B"
        },
        ...
    ]
}
```

**Get 1 Vehicle**
> GET:localhost:5000/api/vehicle/{id}
```
Request: id = 1

ResponseBody
{
    "vehicle": {
        "id": 1,
        "name": "A",
        "status": {
            "time": 160871290000,
            "latitude": 13.84333,
            "longitude": 100.569099,
            "sensors": [
                {
                    "name": "fuel",
                    "value": "50"
                }
            ]
        }
    }
}
```

**Get Vehicle's status with time interval**
> GET:localhost:5000/api/vehicle/{id}/range?from=160871230000&to=160871260000
```
Request: id = 4
RequestQuery
{
    from: 160871230000 // use utc epoch time
    to: 160871260000 // use utc epoch time
}
ResponseBody
{
    "result": [
        {
            "time": 160871230000,
            "latitude": 13.828118,
            "longitude": 100.568918,
            "sensors": [
                {
                    "name": "fuel",
                    "value": "42"
                }
            ]
        },
        {
            "time": 160871260000,
            "latitude": 13.822811,
            "longitude": 100.474439,
            "sensors": [
                {
                    "name": "fuel",
                    "value": "50"
                }
            ]
        }
    ]
}
```




