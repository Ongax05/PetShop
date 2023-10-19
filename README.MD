# Table of Contents

- [Pet Shop API](#pet-shop-api)
- [Project Structure](#project-structure)
- [Database Structure](#database-structure)
- [Custom Endpoints](#custom-endpoints)
- [Endpoint Structure](#endpoint-structure)
- [Special End Points](#special-end-points)
  - [Breed](#breed)
  - [Medicine](#medicine)
  - [Owner](#owner)
  - [Pet](#pet)
  - [Supplier](#supplier)
  - [Veterinarian](#veterinarian)
- [Note](#Note)

# Pet Shop API

Welcome to the  ``Pet Shop API``, a comprehensive .NET Entity Framework project with a modular architecture that includes features like ``JWT authentication``, ``repository pattern``, ``API versioning``, ``rate limiting``, ``Serilog`` for logging, and ``built-in pagination for all GET endpoints``.

1. JWT Authentication: Secure our API with JSON Web Tokens (JWT) to protect our endpoints.

2. Repository Pattern: Utilize a robust repository pattern to abstract data access and ensure a clean and maintainable codebase.

3. API Versioning: Manage multiple API versions effortlessly to support backward compatibility and ongoing development.

4. Rate Limiting: Implement rate limiting to control the number of requests made to our API, preventing abuse and ensuring fair usage.

5. Serilog Logging: Enjoy efficient and customizable logging with Serilog, making it easier to monitor and troubleshoot our API.

6. Pager Gets: All GET endpoints incorporate pagination, allowing you to retrieve large datasets in manageable chunks.

### Project Structure
The ``Pet Shop API`` is organized into four distinct layers, making it easy to manage and extend:

1. Persistence Layer: This layer forms the backbone of the API, housing the Entity Framework (EF) DbContext and entity configurations. It's responsible for managing the interaction with the database, ensuring data integrity and efficiency.

2. Domain Layer: The domain layer encapsulates the core entities and their corresponding interfaces. It provides a structured and object-oriented representation of the data, promoting clean and maintainable code.

3. Application Layer: Here, you'll find all the repositories and the Unit of Work, which facilitates transactions and ensures data consistency. This layer abstracts data access and simplifies interactions with the database, making it easy to manage and extend.

4. API Layer: The API layer is the front-end of the project, containing all controllers, DTOs (Data Transfer Objects), and API configurations. It provides a RESTful interface to interact with the pet shop data, offering a range of endpoints and functionalities.


### Database Structure
The Pet Shop API interacts with a well-designed database structure that consists of 11 tables. Each of these tables follows a consistent pattern, including:

1. Class: Each table corresponds to a single C# class, ensuring a structured and object-oriented approach to data.

2. Interface: An interface is provided for each table, allowing for easy implementation of custom behavior or extensions.

3. Repository: There is a dedicated repository for each table, simplifying data access and manipulation.

4. Controller: A controller is set up for each table, providing basic CRUD operations (GET, POST, PUT, DELETE).

These tables are seamlessly integrated into a Unit of Work, simplifying transactions and ensuring data consistency across operations.

## Custom Endpoints
In addition to the standard CRUD operations, the Pet Shop API is equipped with custom endpoints and methods that cater to specific client requirements. These custom functionalities are designed to meet the unique needs of our project and enhance the value of the API.

## Endpoint Structure

All endpoints within this API follow a consistent structure to maintain code organization and reusability. This structure consists of three key steps:

### Interface Methods

- First, you must define the methods that will be called on the endpoints in their respective interfaces. These methods outline the expected behavior of your endpoints.

### Repository Implementation

- Next, you should implement these methods in their respective repositories. The repositories act as the bridge between your application and the underlying data source (database). They are responsible for executing the data access operations.

### Endpoint Usage

- Finally, you need to utilize the methods from your repositories in the endpoint handlers. This ensures that the endpoint functionality is based on the methods defined in the interfaces and implemented in the repositories. This separation of concerns helps maintain clean, modular, and maintainable code.


# Special End Points

In this section, we will describe all the functions. The endpoints share the same structure as the base GET with pagination. The only variation is in the data returned by methods not covered by the GenericRepository or GenericInterface.

## Breed

```csharp
Task<(IEnumerable<Breed> BreedWithHowManyPets, int Total)> GetHowManyPetsAreInTheBreed(int pageIndex, int pageSize);
```

The Breed Repository includes only one special method for retrieving information about the number of pets in a particular breed and a list of Breeds along with their respective lists of Pets.

## Medicine 

``` csharp
Task<(IEnumerable<Medicine> registers, int totalRegisters)> GetMedicinesByLaboratory(int pageIndex, int pageSize,string LaboratoryName);

Task<(IEnumerable<Medicine> registers, int totalRegisters)> GetMedicinesExpensiveThan(int pageIndex, int pageSize);

Task RestMedicine (int MedicineId, int TotalSold);

Task AddMedicine (int MedicineId, int TotalBought);
```

These are our medicine-related methods:

1. **Filter by Medicine Field**: The first method allows you to filter our medicines by the field laboratort of the `Medicine` entity, to use this method, you must specify the laboratory name, and it will return the medicines associated with that laboratory.

3. **Expensive Medicines**: The second method retrieves medicines that are priced higher than 50,000 COP.

4. **Medicine Movements**: The third and fourth methods are used during medicine movements, for adding and removing medicines from the database.

## Owner

``` csharp
Task<(IEnumerable<Owner> owners,int total)> OwnerWithPets (int pageIndex, int pageSize);
```

This method is straightforward. It involves adding a list of each owner, which contains their pets, using the EF method called `.Include`.

## Pet 

``` csharp
Task<(IEnumerable<Pet> registers, int totalRegisters)> GetPetsBySpecies(int pageIndex, int pageSize,string species);

Task<(IEnumerable<Pet> registers, int totalRegisters)> GetPetsByBreed(int pageIndex, int pageSize,string Breed);

Task<(IEnumerable<Pet> registers, int totalRegisters)> GetPetsByAppointmentReason(int pageIndex, int pageSize,string Reason);

Task<(IEnumerable<Pet> registers, int totalRegisters)> GetPetsByVeterinarian(int pageIndex, int pageSize,string VeterinarianName);
```

These are our pet-related methods:

1. **Filter by Species**: The first method filters our pets by species and returns the filtered pets.

2. **Filter by Breed**: The second method is similar to the first, with the only difference being that it filters pets by breed.

3. **Filter by Appointment Reason**: The third method filters our pets by the reason for their past appointments.

4. **Veterinarian Attendance**: The fourth method provides the pets attended to by a specific veterinarian

## Supplier

``` csharp
Task<(IEnumerable<Supplier> suppliers, int totals)> GetWhoShells (int pageIndex, int pageSize,string medicineName);
```

This method returns all the suppliers who have sold the medicine specified in the parameters.

## Veterinarian

``` csharp
Task<(IEnumerable<Veterinarian> registers, int totalRegisters)> GetVeterinariansBySpeciality(int pageIndex, int pageSize,string speciality);
```

This method returns all the veterinarians who have the speciality specified in the parameters.


### 1.1 Version

Now, in addition to the standard CRUD operations, each controller in the Pet Shop API offers a 1.1 version of basic Getters. These 1.1 versions provide a simple way to retrieve data without pagination. To utilize these 1.1 version Getters in your requests, you must include a query parameter or a header parameter as follows:

**Query Parameter**:
To request data using the 1.1 version of the Getters, include a query parameter like this:
```bash
?version=1.1
```

**Header Parameter**:
Alternatively, you can specify the version using a custom header parameter like this:

```bash
X-Version: 1.1
```

By providing the version information, you can access the simplified Getters for quick data retrieval without pagination. This feature enhances the flexibility of the API and allows you to choose between paginated and non-paginated data retrieval based on your specific needs.

**Note:** This README is for informational purposes only and does not cover all implementation details. It was authored by [Ongax05](https://github.com/Ongax05).