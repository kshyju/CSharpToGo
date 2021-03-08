package main

import (
	"fmt"
	"log"
	"net/http"
)

func main() {
	fmt.Println("Http REST call demo")
	makeRestCallAsync("https://bing.com")
}

func makeRestCallAsync(url string) {
	var resp, httpCallError = http.Get(url)
	if httpCallError == nil {
		fmt.Printf("%s %s", url, resp.Status)
	} else {
		log.Fatal(httpCallError)
	}
}
