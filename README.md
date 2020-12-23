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

