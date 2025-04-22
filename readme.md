# UberAspire
UberAspire is an end-2-end implementation of a ride sharing App backend, like Uber. The services are implemented using ASP.NET Core Web Apis and the frontend is implemented using .NET MAUI and React.
The backend is implemented using a microservice architecture, with each microservice implemented as a separate project.
Read more about it at my [blog](https://www.sidy.me/blog/uberaspire-implement-ride-sharing-backend-app)

## Using the Code
The project is created using .NET Aspire template  which is a opinionated way of building observable services and applications. Just clone the project and hit F5 to run the project.
.NET Aspire host takes care of downloading the required Containers and setting up the environment for you.

## Design
The system design is based on helloInterview Uber System design article.
Please go through the design [here](https://www.hellointerview.com/learn/system-design/problem-breakdowns/uber).

## Components 
As per the design, below are the components are implemented in the project.

### Micro Services
1. RideService
2. RideMatchingService
3. LocationService
4. NotificationService

### Databases
1. Rides Database (PostGress DB)
2. Location DB (Redis)

### Client Side
1. Rider App 
2. Driver App
3. Rider Web App

### Other Infra components
1. API Gateway
2. Redis for Distributed Lock
3. Match Queue

## Usage

ToDo:
1. Add Snapshots
2. Features demo videos

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
