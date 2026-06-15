# Microservices

## Pros of Microservices :

### Flexibility: 

It allows flexibility in terms of having smaller isolated teams and also technology choices: languages, frameworks, databases, etc.

Microservices can be scaled independently, without having to scale the whole system.

### Resilience: 

It allows more fault-tolerant systems, as a failure in one service can be isolated and handled without affecting the entire system.

### Agility: 

It allows faster development and deployment cycles, as changes can be made to a single service without impacting the entire system, making easier to test.

### Reusability: 

It can be reused across multiple applications, which can result in cost savings and increased efficiency.

## Drawbacks:

### Complexity: 

It can increase the complexity of the system, as there are more moving parts and more interactions between services.

### Testing and Debugging: 

Testing and debugging can be more complex, as it requires testing each service individually, as well as testing their interactions.

### Monitoring and Management: 

It requires more monitoring and management, as there are more services to keep track of and manage.

### Inter-service communication: 

It increases the number of network calls between services, which can lead to increased latency, and if not handled properly, to cascading failures, especially for synchronous communication.

### Security: 

It can make it more challenging to implement security measures, as each service may need to be secured individually.


## API Gateway

API Gateway is one of the essential Microservices pattern which is used to provide a single entry point for external consumers to access the services. It acts as a reverse proxy and routing layer, which is responsible for request routing, composition, protocol translation, handle cross-cutting concerns such as security, rate limiting, and caching at the edge of the architecture, can aggregate multiple services into a single response and decouples the external consumers from the internal implementation of the services. This allows the services to evolve and scale independently, without affecting the external consumers.

## Patterns

### Circuit Breaker pattern

It improves Service availability. Circuit breaker pattern is a technique used to prevent cascading failures by temporarily preventing further calls to a service that is failing frequently. It helps to improve the resiliency of the system.

<p align="center">
  <img src="./img/circuitbreaker.png?raw=true">
</p>

### Query Responsibility Segregation

CQRS stands for Command Query Responsibility Segregation. It’s one of the popular Microservices design pattern that separates the read and write operations in a system and allows them to evolve independently. It allows for a more scalable and performant system, but also increase complexity.

<p align="center">
  <img src="./img/CQRS.png?raw=true">
</p>

### Outbox Pattern

When your API publishes event messages, it doesn’t directly send them. Instead, the messages are persisted in a database table. After that, A job publish events to message broker system in predefined time intervals.

Outbox pattern ensures that the message will eventually reach its target.


<p align="center">
  <img src="./img/OutboxPattern.png?raw=true">
</p>


### Retry pattern 

It is a technique used in Microservices architecture to handle service failures automatically. It involves automatically retrying a failed service call a certain number of times, with a delay between retries.

## Coupling and Cohesion

### Coupling: 

Coupling is specified as a relationship between module A and another module B.

### Cohesion: 

Cohesion is the relationship between 2 or more parts within a module.

## RabbitMQ:

RabbitMQ is an open source message broker software (sometimes called message-oriented middleware) that implements the Advanced Message Queuing Protocol (AMQP).

RabbitMQ provides persistence by writing messages to disk before processing them so that they can be recovered if needed.

An exchange accepts messages from the producer application and routes them to message queues with help of header attributes, bindings, and routing keys. A binding is a "link" that you set up to bind a queue to an exchange.

<p align="center">
  <img src="./img/exchanges-topic-fanout-direct.png?raw=true">
</p>

## CAP Theorem
In the presence of the network partition, a distributed system is either available or consistent

<p align="center">
  <img src="./img/partition.webp?raw=true">
</p>

### Availability: 

When a partition occurs, all nodes remain available but those at the wrong end of a partition might return an older version of data than others. (When the partition is resolved, the AP databases typically resync the nodes to repair all inconsistencies in the system.)

AP (Availability and Partition tolerance)

*Partition tolerance* is when the system continues to operate despite an arbitrary number of messages being dropped (or delayed) by the network between nodes.


### Consistency: 

When a partition occurs between any two nodes, the system has to shut down the non-consistent node (i.e., make it unavailable) until the partition is resolved.

## Reference:

https://medium.com/javarevisited/50-microservices-interview-questions-for-java-programmers-70a4a68c4349

