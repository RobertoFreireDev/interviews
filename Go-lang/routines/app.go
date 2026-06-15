package main

import (
	"fmt"
	"sync"
	"time"
)

var m = sync.RWMutex{}
var withReadLock bool = true
var dbData = []string{"id1", "id2", "id3", "id4", "id5"}
var results = []string{}
var wg = sync.WaitGroup{}

func main() {
	//runsequencially()
	//fmt.Println("")
	//runconcurrently()
	//fmt.Println("")
	runsafeconcurrently()
	fmt.Println("")
}

func runsafeconcurrently() {
	suffix := ""
	if withReadLock {
		suffix = " with read lock"
	}
	fmt.Println("Run Safe Concurrently" + suffix)
	t0 := time.Now()
	for i := 0; i < len(dbData); i++ {
		wg.Add(1)
		go dbCall3(i)
	}
	wg.Wait()
	fmt.Printf("\nTotal execution time: %v", time.Since(t0))
	fmt.Printf("\nResults: %v", results)
}

func dbCall3(i int) {
	var delay float32 = 1000
	time.Sleep(time.Duration(delay) * time.Millisecond)
	save(dbData[i])
	log()
	wg.Done()
}

func save(result string) {
	m.Lock()
	results = append(results, result)
	m.Unlock()
}

func log() {
	if withReadLock {
		m.RLock()
	}
	fmt.Println("Current results: ", results)
	if withReadLock {
		m.RUnlock()
	}
}

func runconcurrently() {
	fmt.Println("Run Concurrently")
	t0 := time.Now()
	for i := 0; i < len(dbData); i++ {
		wg.Add(1)
		go dbCall1(i)
	}
	wg.Wait()
	fmt.Printf("\nTotal execution time: %v", time.Since(t0))
	fmt.Printf("\nResults: %v", results)
}

func dbCall1(i int) {
	var delay float32 = 1000
	time.Sleep(time.Duration(delay) * time.Millisecond)
	results = append(results, dbData[i])
	fmt.Println("Result from database: ", dbData[i])
	wg.Done()
}

func runsequencially() {
	fmt.Println("Run  Sequencially")
	t0 := time.Now()
	for i := 0; i < len(dbData); i++ {
		dbCall2(i)
	}
	fmt.Printf("\nTotal execution time: %v", time.Since(t0))
}

func dbCall2(i int) {
	var delay float32 = 2000
	time.Sleep(time.Duration(delay) * time.Millisecond)
	fmt.Println("Result from database: ", dbData[i])
}
