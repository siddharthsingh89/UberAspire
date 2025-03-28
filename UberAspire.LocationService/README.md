## Location Service
Location Service offer location based services to support RideMatching functionality. 
It is a Restful service that provides the following functionalities:
1. Add Location Details of Drivers 
2. Get Nearby drivers for a given location

## API Documentation

**POST /location/addlocation**

```json
{
  "driverId": "string",
  "latitude": "string",
  "longitude": "string"
}
```


**POST /location/getnearbydrivers**

```json
{
  "latitude": "string",
  "longitude": "string",
  "radius": "string",
  "unit": "string"
}
```

## DataStore
* It uses Redis(default container provided by Aspire) as the datastore to store and retrieve geospatial info.
* GEOADD command is used to add the location details of the drivers.
* GEORADIUS command is used to get the nearby drivers for a given location.

