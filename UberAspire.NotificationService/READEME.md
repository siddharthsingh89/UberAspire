## Notification Service
UberAspire is ride sharing Application. Notification plays an important role in Ride Sharing as the communication 
between the rider and driver is very important and needs to be Realtime.

Notification Service is responsible for sending these notifications to the riders and drivers about the ride status.
It uses Azure Notification Hub to send the notifications to Android and other platforms.
Currently the service is used for sending the Ride Request to the Driver. It can be used for other notification use cases as well.



## Design

Notification Service makes use of Azure Notification Hubs which provide an easy-to-use and scaled-out push engine that enables you to send notifications to any platform (iOS, Android, Windows, etc.)
from any back-end (cloud or on-premises).