# Go

## first program

go run app.go

Go compiles your program to a temporary directory, producing a binary, It immediately runs that binary and after execution, the binary and build artifacts are deleted automatically.

You can see the actual temp directory by using: go build -work app.go

## packages and module

to create a module: go mod init packagesandmoduleexample

this folder where go.mod lives and all subfolders belongs to module packagesandmoduleexample

to use all Go files in the folder, use: go run . 
or use: go build

## Variables, Values & Operators


## Routines

```
Run Concurrently
Result from database:  id1
Result from database:  id2
Result from database:  id3
Result from database:  id4
Result from database:  id5

Total execution time: 1.0015936s
Results: [id1 id2 id4 id5]

Run Safe Concurrently
Current results:  [id1]
Current results:  [id1 id2 id4]
Current results:  [id1 id2]
Current results:  [id1 id2 id4 id5]
Current results:  [id1 id2 id4 id5 id3]

Total execution time: 1.0020566s
Results: [id1 id2 id4 id5 id3]

Run Safe Concurrently with read lock
Current results:  [id3]
Current results:  [id3 id1]
Current results:  [id3 id1 id2]
Current results:  [id3 id1 id2 id5]
Current results:  [id3 id1 id2 id5 id4]

Total execution time: 1.003036s
Results: [id3 id1 id2 id5 id4]
```

## Channels

- Hold data
- thread safe
- listen for data (added/removed) and can block code execution until one of these events happens

## Go UI interface using raylib