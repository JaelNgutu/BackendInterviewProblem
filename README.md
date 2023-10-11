
# Advanced product search api challenge

A web api used to search for products


## Architecture

**Clean Architecture** Architecture used for this api


## 
[![portfolio](https://miro.medium.com/v2/resize:fit:640/0*Rou74nFJusFbVLgQ)

#### Presentation Layer:

This is the topmost layer of the application and is responsible for handling user interactions and presenting information to the user.

#### Application Layer:

It contains the core application logic and coordinates the interaction between the presentation layer and the domain layer

#### Domain Layer:

Contains the domain model, which represents the core business concepts and entities.

#### Infrastructure Layer:

Deals with the technical and external aspects of the application.
It contains implementations of interfaces defined in the application layer and interacts with external resources such as databases



## Pattern

**CQRS (Command Query Responsibility Segregation)** pattern was used in the implementation of this api.  It's a pattern that separates the concerns of handling commands (writes) and queries (reads) into distinct components.



