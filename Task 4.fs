open System

type Ticket = { seat:int; customer:string } // Creates the ticket type

//Creates ticket list with empty customer field
let mutable tickets = [for i in 1..10 -> {Ticket.seat = i; Ticket.customer = ""}] 

// Function that outputs all the tickets in list with corresponing ticket seat and customer name
let displayTickets tickets =
    tickets |> List.iter (fun ticket -> // function is applies to all items in ticket list
        Console.WriteLine("Seat number: {0}, Customer fullname: {1}", ticket.seat, ticket.customer))

// Books ticket with paramaters for the values
let bookSeat (customerFullname:string, seat:int) tickets =
    if seat >= 1 && seat <= 10 then //make sure seat number is valid (between 1-10)
        let mutable seatIsAvailable = true
        for ticket in tickets do //loops through all tickets in list
            if ticket.seat = seat && ticket.customer <> "" then //makes sure  requested seat is empty
                seatIsAvailable <- false
        if seatIsAvailable then
            // Creates a new list with the the customers name and booked seat
            let newTickets =
                tickets
                |> List.map (fun allSeats ->
                    if allSeats.seat = seat then { allSeats with customer = customerFullname }
                    else allSeats)
            Console.WriteLine("Seat number {0} booked for {1}", seat, customerFullname)
            Some newTickets // When seat can be created
        else
            Console.WriteLine("Seat number {0} is no longer available.", seat)
            None // When seat cannot be allocated
    else
        Console.WriteLine("Invalid seat number")
        None // When seat does not exist - so cannot be allocated

// TESTING


let testSeatBooking () = 
    //assigning test values
    let booking1 = "Jake Watson"
    let booking2 = "Stacy Khan"
    match bookSeat (booking1, 7) tickets with
    | Some newTickets1 -> //create new list if booking sucessful
        match bookSeat (booking2, 8) newTickets1 with // makes second booking attempt using new list
        // if booking2 seat is the same as booking1 (eg. 7) then program will not continue with booking2 )
        | Some newTickets2 ->
            displayTickets newTickets2 //updates new tickets list  after booking
        | None -> ()
    | None -> ()



displayTickets tickets // tests function
Console.WriteLine("--------") 
testSeatBooking () // //calls function so I can test booking