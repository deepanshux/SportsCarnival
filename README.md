# Sports Carnival #

This project is a .NET console application that map the players in a team according to their game preference.

### What is this repository for? ###

This repository is for learning purpose only. This project consist the following things.
* SOLID Principles
* Design Pattern
* Project Layers
* MYSQL 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites
To build and run this project, you need to have .NET SDK and visual studio installed on your machine.

## SOLID Principle

These are some of the major principles which have been used in the project. 

### Single Responsibility Principle (SRP) :
Each class has only one responsibility, which makes it easier to understand and maintain.

### Open/Closed Principle (OCP): 
Classes should be open for extension but closed for modification, which means that new functionality can be added without changing the existing code.

### Interface Segregation Principle (ISP): 
Clients should not be forced to depend on interfaces they do not use, which means that interfaces should be tailored to the specific needs of the clients that use them.

### Dependency Inversion Principle (DIP): 
High-level modules should not depend on low-level modules; both should depend on abstractions. Abstractions should not depend on details; details should depend on abstractions.

### Boundaries : 
When working with a third-party API in a project that follows SOLID principles, you may want to create a boundary to ensure that the API is encapsulated and the rest of the application is decoupled from it.

## Project Layers

This project is organized into three layers: the Repository layer, the Service layer, and the Controller layer.

### Repository Layer
The Repository layer is responsible for interacting with the data storage system, which could be a database or a file system. This layer is implemented using the Repository design pattern, which provides a layer of abstraction between the data storage system and the rest of the application.

### Service Layer
The Service layer is responsible for implementing the business logic of the application. This layer provides a set of operations that can be used by the Controller layer to interact with the Repository layer. The Service layer is implemented using the Service design pattern, which provides a layer of abstraction between the Controller layer and the Repository layer.

### Controller Layer
The Controller layer is responsible for handling user requests and returning appropriate responses. This layer is implemented using the Controller design pattern, which provides a layer of abstraction between the user interface and the rest of the application.

## Design Pattern

### Singleton Design Pattern
The Singleton design pattern is a creational pattern that ensures that a class has only one instance, and provides a global point of access to that instance. This pattern is useful when you need to limit the number of instances of a class that can be created, or when you want to ensure that all instances of a class have the same state.


### Contribution guidelines ###

* Writing tests
* Code review
