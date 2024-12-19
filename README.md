# SharpWebApp

## Overview
SharpWebApp is a web application built with ASP.NET Core. This application serves as a template for building modern web applications with a focus on performance and scalability.

## Features
- ASP.NET application using Razor pages
- Reading application settings from the App Configuration service
- Reading secrets from a Key Vault resource
- Entity Framework Core
- Responsive Design

## Getting Started

### Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/SimpleWebApp.git
    ```
2. Navigate to the project directory:
    ```sh
    cd SimpleWebApp
    ```
3. Restore the dependencies:
    ```sh
    dotnet restore
    ```

### Running the Application
1. Update the database:
    ```sh
    dotnet ef database update
    ```
2. Run the application:
    ```sh
    dotnet run
    ```

### Building for Production
1. Publish the application:
    ```sh
    dotnet publish -c Release
    ```