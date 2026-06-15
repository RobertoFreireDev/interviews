package greet

import (
	"bufio"
	"fmt"
	"os"
)

func Hello(name string) {
	fmt.Printf("Hello, %s!\n", name)
	fmt.Print("Press Enter to exit...")
	bufio.NewReader(os.Stdin).ReadBytes('\n')
}
