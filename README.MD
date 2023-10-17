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

#### **I will explain them all below:**
