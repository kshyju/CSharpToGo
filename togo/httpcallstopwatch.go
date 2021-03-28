package main

import (
	"fmt"
	"log"
	"net/http"
	"time"
)

func main() {

	start := time.Now()
	for i := 0; i < 5; i++ {
		makeRestCallAsync("https://bing.com")
	}
	end := time.Now()
	elapsed := end.Sub(start)

	fmt.Printf("Total Elapsed time %s", elapsed)
}

func makeRestCallAsync(url string) {
	start := time.Now()
	var resp, httpCallError = http.Get(url)
	if httpCallError == nil {
		end := time.Now()
		elapsed := end.Sub(start)

		fmt.Printf("%s %s Elapsed time: %s \n", url, resp.Status, elapsed)
	} else {
		log.Fatal(httpCallError)
	}
}
