# Design Netflix

## What is the scope?

Videos and User activities

Cross Platfrom (mobile app, website, desktop application and tv apps)

No Integrations

## Core Domain

Videos 

    Video Series (Ex: tv shows)               - 1k (average,50 videos each and 30 min)
    Single Video (Ex: Documentary or Movie)   - 2K (average 2 hours)

User Activities

    List of videos watched
    - VideoId : id
    - Completed : bool
    - StoppedAt : TimeStamp
    - Like : Like | didn't like | Super Like
    - Category : Horror | Comedy | ...

## Access

    200M active users
    50M peak concurrent users

## Availability or Consistency? 

Availability, user must access netflix at anytime, despite any presence of the network partition

## Features

Show list of videos grouped by category or other info from user activity (Watch Again, Not Finished and etc). 

Stream Videos

## High Level Design

Api for returning list of videos

    - Front End will request List of videos grouped by category or other info from user activity
    - Back end will process aggregating with user Activities.
    - Cache user activities
    - Load Balance for multiple instances of this application
    - Store user activities in NoSQL distributed database (Focus on Availability instead of a consistency)

Api for stream a video given a videoId

    - Load Balance for multiple instances of this application
    - Store videos in a cloud service that suports file stream service

## Notes:

### CAP Theorem  

In the presence of the network partition, a distributed system is either available or consistent

**Availability:**
When a partition occurs, all nodes remain available but those at the wrong end of a partition might return an older version of data than others. (When the partition is resolved, the AP databases typically resync the nodes to repair all inconsistencies in the system.)

**Consistency:**
When a partition occurs between any two nodes, the system has to shut down the non-consistent node (i.e., make it unavailable) until the partition is resolved.

### HTTP response status codes:

    - 100-level (Informational) – server acknowledges a request

    - 200-level (Success) – server completed the request as expected

    --> 200 OK
    --> 201 Created 
    --> 202 Accepted 
    --> 204 No Content

    - 300-level (Redirection) – client needs to perform further actions to complete the request

    - 400-level (Client error) – client sent an invalid request

    --> 400 Bad Request 
    --> 401 Unauthorized
    --> 403 Forbidden
    --> 404 Not Found 

    - 500-level (Server error) – server failed to fulfill a valid request due to an error with server




