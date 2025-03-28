## Ride Service
Ride Service is responsible for managing the rides. It provides the following functionalities:
1. Create a new ride
2. Cancel a ride
3. Get ride details
4. Get ride history
5. Create a Fare Estimate based on the ride details

## Features
1. It makes use of Mapping Services (google, Bing) to generate the route and estimate the fare.
2. It has a pricing engine that calculates the fare based on the distance and time.
3. It uses the Notification Service to notify the riders and drivers about the ride status.
4. It uses the RideMatching Service to match the drivers with the riders.


## API Documentation

To be added


## DataStore
It uses SQL Server (default container provided by Aspire) as the datastore to store the ride details.
