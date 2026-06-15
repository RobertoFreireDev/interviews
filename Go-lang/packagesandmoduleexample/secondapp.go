package main

import (
	"packagesandmoduleexample/greet" // import the package by module name + folder
)

func mainHello(value string) {
	greet.Hello(value)
}
