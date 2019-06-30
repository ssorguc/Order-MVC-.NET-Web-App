# Order-MVC-.NET-Web-App
Small web application used to implement MVC .NET fundamental functionalities

DEFINITION OF THE TASK:
Description:
Create pages in ASP MVC to handle Orders in two tables with full CRUD Operations
- Master Table: - Orders
Contains columns: - order ID, Date, Customer Id, Total Amount
- Details Table: - Order Items
Contains columns: - order Items Id, Item ID, Unit Id, Amount
Required features:
- Basic user management (Add – Edit – Update – Delete).
- Login.
- Orders management (Add – Edit – Update – Delete).

1. Validation is very important.
2. Coding readability.
3. Use EF Code first.
4. Implement User management ASP User Membership.

WHAT HAVE I COMPLETED:
- Created Log in form, Orders List form, Edit form, Create form, Delete options
- Used Entity Framework to create and connect to Code-First Local DataBase
- Default and Custom Validation examples
- Handling HTTP POST AND HTTP GET Request

WHAT IS MISSING AND WHAT HAS TO BE IMPROVED:
- havent completed creation and edit opetions for all properties of the order, data binding in the create and edit acctions in following views should  be handled better
- user managment is still missing, log in should be improved so that authorisation and authentication is enabled (for example when you log in then you can see the orders list that belong to you, when addmin logs in he can see all the ongoing orders, and annonymous visitors can only see the log in and home page)
- possible architectural changes: application is still simple at the moment, but home controller might get overloaded. Creating two more controllers CustomerControler and OrderControler would do better job in concerns separation
- using a framework like Angular and React would improve front end development process and concern separation, aswell as the design and user friendliness


PROBLEMS I HAVE ENCOUNTERED THAT CAN BE FURTHER DISCUSSED AND WORKED ON:
- Data Binding of complex Models and how to always hand this efficiently in MVC .NET
- When to  use View-Models layer 
- I have few exceptions I havent handeled yet because I havent completed edit and create functionalities (Save and Create Actions)
- Authorisation and Authentication solutions for smaller applications vs more complex solutions that guaranty data safety

