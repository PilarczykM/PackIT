# PackIT - Vacation Packing Application

PackIT is a simple application designed to assist users in packing their suitcase for vacations. It takes into consideration various factors such as gender, temperature, and travel duration to generate a personalized packing list. PackIT follows a clean architecture approach, dividing the application into distinct layers: Domain, Application, Infrastructure, and API (Web). It also implements the CQRS pattern to efficiently manage data and commands.

## Policies

PackIT follows specific policies when creating packing lists:

- **Gender**: Users can specify their gender as either "Female" or "Male," and the application will generate a list of clothing items accordingly.
- **Temperature**: Users can select "High" or "Low" temperature settings based on their travel destination, ensuring they pack suitable clothing.
- **Universal**: Users can add general items to their packing list that are not influenced by gender or temperature.

## Business Requirements

PackIT allows users to create personalized packing lists with the following information:

- **Name**: Users should provide a name for their packing list.
- **Gender**: Specify your gender as "Female" or "Male."
- **Temperature**: Choose between "High" or "Low" temperature settings.
- **Localization**: Enter the location of your vacation.
- **Travel days**: Indicate the duration of your trip.

The application retrieves temperature data from an external source based on the provided location. It then prepares an initial list of clothing items tailored to the chosen gender and temperature.

Users can perform the following actions with their packing list:

- **Add Items**: Users can add their own items to the packing list as needed.
- **Mark Items as Packed**: Check off items on the list once they are packed.
- **Remove Items**: Remove items from the list if they are no longer needed.
- **Remove List**: Delete the entire packing list if necessary.

## Database Setup

PackIT uses a PostgreSQL database for data storage. To set up the database using Docker Compose, follow these steps:

1. Clone this repository to your local machine.
2. Ensure you have Docker and Docker Compose installed.
3. Open a terminal and navigate to the root folder of the project.
4. Run the following command to start the PostgreSQL database container:

```bash
docker-compose up -d
```

The default login credentials for the PostgreSQL database are as follows:

- **Username**: postgres
- **Password**: 
- **Database Name**: packIt

You can connect to the database using your preferred PostgreSQL client or access it through the application.
Remember that on first run application will run migration.
appsettings.json
```
...
"Postgres": {
  "ConnectionString": "Host=localhost;Database=packIt;Username=postgres;Password="
}
```

## Technologies Used

PackIT is developed using the following technologies and tools:

- **.NET Core**: The application is built using the .NET Core framework, ensuring cross-platform compatibility and robust performance.
- **Entity Framework**: Entity Framework is used for data access, providing a convenient way to interact with the database.
- **xUnit**: Unit testing is implemented with xUnit, a popular testing framework for .NET applications, ensuring the reliability of the codebase.
- **Shouldly**: Shouldly is used for testing to enhance the readability of unit tests and assertions, making it easier to understand the test outcomes.

## Getting Started

To get started with PackIT, follow these steps:

1. Clone this repository to your local machine.
2. Ensure you have .NET Core and Entity Framework installed.
3. Run docker or prepare your own database.
4. Run the application and access it through the API (Web) to create your packing lists.

## Feedback and Contribution

Welcome feedback and contributions to make PackIT even better. Feel free to open issues, submit pull requests, or share your suggestions to enhance this application.

## License

This application is licensed under the [MIT License](LICENSE).
