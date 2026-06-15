package main

import (
	"fmt"
	"math"
)

func main() {
	var investimentAmount float64 = 1000
	const expectedReturnRate = 5.5
	years := 10

	fmt.Print("Type investiment amount\n")
	fmt.Scan(&investimentAmount)
	var futureValue = investimentAmount * math.Pow((1+expectedReturnRate/100), float64(years))
	fmt.Printf("Future value: %.2f\n", futureValue)
}
