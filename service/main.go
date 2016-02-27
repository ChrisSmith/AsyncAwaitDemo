package main

import (
	"fmt"
	"log"
	"net/http"
	"strconv"
	"time"
)

func main() {

	srv := &http.Server{
		ReadTimeout:  30 * time.Second,
		WriteTimeout: 30 * time.Second,
		Addr:         ":8080",
	}

	http.HandleFunc("/search", search)

	log.Print("Listening on " + srv.Addr)
	log.Fatal(srv.ListenAndServe())
}

func search(w http.ResponseWriter, r *http.Request) {

	if delay, err := strconv.ParseInt(r.FormValue("delay"), 10, 32); err != nil {
		fmt.Fprintf(w, "invalid delay %v\n", err)
	} else {
		time.Sleep(time.Duration(delay) * time.Millisecond)

		fmt.Fprintf(w, "Hello World\n")
	}
}
