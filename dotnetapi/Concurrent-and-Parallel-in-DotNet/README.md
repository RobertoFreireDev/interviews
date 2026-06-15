# Concurrent and Parallel in C#

## Content

### Sequential programming


Sequential programming is the act of accomplishing things in steps

<p align="center">
  <img src="https://user-images.githubusercontent.com/41349878/149008386-45dc2979-3d86-4678-8c44-293ae3505af6.png?raw=true">
</p>


### Concurrent programming


Concurrent programming runs multiple tasks at the same time. Concurrency describes the ability to run several programs or multiple parts of a program
at the same time. Using concurrency within an application provides actual multitasking, dividing the application into multiple and independent processes that run at the same time (concurrently) in different threads. This can happen either in a single CPU core or in parallel, if multiple CPU cores are available.

Concurrency gives the impression that these threads are running in parallel and that different parts of the program can run simultaneously. But in a single-core environment, the execution of one thread is temporarily paused and switched to another thread.



### Parallel programming


Parallelism is the concept of executing multiple tasks at once concurrently, literally at the same time on different cores, to improve the speed of the application

All parallel programs are concurrent (runs multiple tasks/things at the same time), but not all concurrency is parallel because parallelism requires hardware support (multiple cores)


<p align="center">
  <img src="https://user-images.githubusercontent.com/41349878/149010407-aae2b1fe-59f2-4f45-8588-dc346337cabe.png?raw=true">
</p>


Parallelism can be achieved when a single task is split into multiple independent
subtasks

<p align="center">
  <img src="https://user-images.githubusercontent.com/41349878/149010678-e75751a4-3778-4d39-b655-eb2446819bd3.png?raw=true">
</p>


### Multitasking


Multitasking is the concept of performing multiple tasks over a period of time by executing them concurrently.

Computer multitasking was designed in the days when computers had a single CPU to concurrently perform many tasks while sharing the same computing resources.

Each task has a different shade, indicating that the context switch in a single-core machine gives the illusion that multiple tasks run in parallel, but only one task is processed at a time.

<p align="center">
  <img src="https://user-images.githubusercontent.com/41349878/149011060-66378db1-1807-468b-bfdb-0b0e731ff076.png?raw=true">
</p>


### Multithreading 

Multithreading is an extension of the concept of multitasking, aiming to improve the performance of a program by maximizing and optimizing computer resources. Multithreading is a form of concurrency that uses multiple threads of execution. 

Multithreading differs from multitasking: Unlike multitasking, with multithreading, the threads share resources

Multithreading is hardware-agnostic, which means that it can be performed regardless of the number of cores. Parallel programming is a superset of multithreading. You could use multithreading to parallelize a program by sharing resources in the same process, for example, but you could also parallelize a program by executing the computation in multiple processes or even in different computers. 

Relationship between concurrency, parallelism, multithreading, and multitasking in a single
and a multicore device

<p align="center">
  <img src="https://user-images.githubusercontent.com/41349878/149012012-df3c4963-eecf-4587-99bf-77101a45da5c.png?raw=true">
</p>


### Mutual Exclusion


Two threads (Thread 1 and Thread 2) run in parallel, both trying to access and modify the shared value x. If Thread 2 tries to read from the same memory location while Thread 1 writes back an updated value, the value of x changes. This result is data corruption or race condition

Lock solves this issue [Lock in C#](https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/statements/lock) but can lead to deadlock.

<p align="center">
  <img src="https://user-images.githubusercontent.com/41349878/149014937-598c7375-57ac-4c28-91f6-4b759536f143.png?raw=true">
</p>


### Deadlock


A Deadlock is a situation where an application locks up because two or more activities are waiting for each other to finish.

Thread 1 acquires lock A.
Thread 2 acquires lock B.
Thread 1 attempts to acquire lock B, but it is already held by Thread 2 and thus Thread 1 blocks until B is released.
Thread 2 attempts to acquire lock A, but it is held by Thread 1 and thus Thread 2 blocks until A is released.

```csharp
    
    object lockA = new object();
    object lockB = new object();

    Thread 1 void t1()
    {
        lock (lockA)
        {
            lock (lockB)
            {
                /* ... */
            }
        }
    }
    Thread 2 void t2()
    {
        lock (lockB)
        {
            lock (lockA)
                {
                /* ... */
                }
        }
    }
```

## Glossary:

**LOCK** : The lock statement acquires the mutual-exclusion lock for a given object, executes a statement block, and then releases the lock. While a lock is held, the thread that holds the lock can again acquire and release the lock. Any other thread is blocked from acquiring the lock and waits until the lock is released.

**PROCESS** : A process is an instance of a program running within a computer system. Each process has one or more threads of execution, and no thread can exist outside a process.

**THREAD** : A thread is a unit of computation (an independent set of programming instructions designed to achieve a particular result), which the operating system scheduler independently executes and manages.

**THREADSAFE** : A method is called threadsafe when the data and state don’t get corrupted if two or more threads attempt to
access and modify the data or state at the same time.

## Reference:


Book Riccardo Terrell - Concurrency in .NET_ Modern patterns of concurrent and parallel programming-Manning (2018)

Book Parallel Programming and Concurrency with C# 10 and .NET 6: A modern approach to building faster, more responsive, and asynchronous .NET applications using C#
