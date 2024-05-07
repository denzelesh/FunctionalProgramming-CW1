open System

type Account(accountNumber: string, initialBalance: float) = //creates the type
    let mutable balance = initialBalance // Allows for balance to be changed
    member this.AccountNumber = accountNumber // Used to return value of account in instance
    member this.Balance = balance //  Used to return value of balance in instance

    member this.Withdrawal(amount: float) = //Creates the withdraw method
    // stament below will output differnet message based on balance amount and withdraw/deposit amount.
        if amount > balance then
            Console.WriteLine("Hi, your account number is {0} and your balance is £ {1}", this.AccountNumber, this.Balance)
            Console.WriteLine("Begining withdrawl process. Please wait")
            Console.WriteLine("Your withdrawal was canceled as you don't have enough money in this account.")
            Console.WriteLine("Please try again later.")
            Console.WriteLine("-----------")
        else
            balance <- balance - amount
            Console.WriteLine("Hi, your account number is {0} and your balance is £ {1}", this.AccountNumber, this.Balance)
            Console.WriteLine("Begining withdrawl process. Please wait")
            Console.WriteLine("You've sucessfully withdrawn £ {0}. Your new account balance is: £ {1}", amount, this.Balance)
            Console.WriteLine("-----------")

    member this.Deposit(amount: float) =  // Creates the deposit method
        balance <- balance + amount
        Console.WriteLine("Hi, your account number is {0} and your balance is £ {1}", this.AccountNumber, this.Balance)
        Console.WriteLine("Attempting to deposit money into your account. Please wait")
        Console.WriteLine("You've sucessfully deposited £ {0}. Your new account balance is: £ {1}", amount, this.Balance)
        Console.WriteLine("-----------")

    member this.Print() =  //Creates the  method to output current account details.
        Console.WriteLine("Hi, your account number is {0} and your balance is £ {1}", this.AccountNumber, this.Balance)
        Console.WriteLine("-----------")

// Function to check account details and show message
let CheckAccount (accountBeingChecked: Account) = 
    Console.WriteLine("Hi, your account number is {0}", accountBeingChecked.AccountNumber)
    Console.WriteLine("Retreiving your account balance. Please wait.")
    match accountBeingChecked.Balance with // Uses pattern matching to output correct message based on account balance.
    | balance when balance < 10.0 -> 
        Console.WriteLine("Your account balance is low.", accountBeingChecked.AccountNumber)
        Console.WriteLine("-----")

    | balance when balance >= 10.0 && balance <= 100.0 -> 
        Console.WriteLine("Your account balance is OK.", accountBeingChecked.AccountNumber)
        Console.WriteLine("-----")
        

    | balance -> 
        Console.WriteLine("Your account balance is high.", accountBeingChecked.AccountNumber)
        Console.WriteLine("-----")

// TESTING

// Creates a list of accounts using Account Type
let accounts = [
    Account("0001", 0.0)
    Account("0002", 51.0)
    Account("0003", 5.0)
    Account("0004", 57.0)
    Account("0005", 99.0)
    Account("0006", 9.0)
]


// Loops through all elements in accounts list and runs the CheckAccount function on them one by one.
accounts |> List.iter CheckAccount