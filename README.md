# OOP G18 Final Assignment - APPrint

## Overview

This project is the final assignment for my OOP Course. The application, APPrint, is a Windows Forms application that allows administrators, managers, workers, and customers to manage user accounts, generate reports, handle requests, and perform various tasks. The project is implemented using C# and .NET Framework, with a SQL Server database for storing user data and other information.

## Features

### Admin Features

1. **Admin Edit User**: Allows administrators to edit existing user accounts.
2. **Admin Home Page**: Provides a central hub for administrative actions, such as editing users, registering new users, viewing reports, and logging out.
3. **Admin Register User**: Facilitates the registration of new users.
4. **Admin Reports**: Generate various types of reports, including yearly, service requests, and customer reports.
5. **Admin User Edit Confirm**: Confirms and saves the changes made to a user's profile.

### Manager Features

1. **Manager Home Page**: A central hub for manager actions, including assigning jobs, viewing modes, editing profiles, and logging out.
2. **Assign Job**: Allows managers to assign jobs to workers based on requests.
3. **Manager Edit Profile**: Enables managers to update their profile information.
4. **Manager View Mode**: Displays all requests and their assigned workers.

### Worker Features

1. **Worker Home Page**: A central hub for worker actions, including viewing and updating assigned jobs, editing profiles, and logging out.
2. **Worker Update**: Allows workers to update the status of their assigned jobs.
3. **Worker Edit Profile**: Enables workers to update their profile information.
4. **Worker View Page**: Displays all requests assigned to the worker with options to filter and search.

### Customer Features

1. **Customer Home Page**: A central hub for customer actions, including viewing services, making requests, editing profiles, and checking the status of requests.
2. **Customer Edit Profile**: Allows customers to update their profile information.
3. **Customer Request Page**: Facilitates the creation and confirmation of service requests.
4. **Customer View Services Page**: Displays available services to the customer.
5. **Customer View Status**: Shows the status of the customer's requests.

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/devaraalandra/print-service-manager.git
    ```

2. Open the solution file `OOP_G18_Final_Assignment_APPrint.sln` in Visual Studio.

3. Update the `Config.ConnectionString` with your SQL Server connection string.

4. Build and run the application.

## Usage

1. **Login**: Use the login form to access the application as an admin, manager, worker, or customer.
2. **Navigate**: Use the home page of each role to navigate to different functionalities such as editing profiles, viewing requests, and generating reports.

## Contributors

- Devara Alandra Wicaksono (Lead Developer)
- Masaya Yamano
- Christopher Rustandi
- M. Danial Muzaffar Bin Khairol Kamshar

## Acknowledgments

- Special thanks to our course instructor, Dr. Kulothunkan Palasundram for guiding us on this project.
