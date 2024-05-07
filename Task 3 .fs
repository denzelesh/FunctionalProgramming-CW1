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

// Filter accounts into two sequences based on balance
let accountsWithAHighBalance = accounts |> List.filter (fun accountBeingChecked -> accountBeingChecked.Balance >= 50.0)
let accountsWithALowBalance = accounts |> List.filter (fun accountBeingChecked -> accountBeingChecked.Balance >= 0.0 && accountBeingChecked.Balance < 50.0)

// Print the sequences
Console.WriteLine("Below are all the accounts containing balance of exactly £50 or higher:")
for accountBeingChecked in accountsWithAHighBalance do
    Console.WriteLine("Bank Account Number: {0}, Current Balance: £ {1}", accountBeingChecked.AccountNumber, accountBeingChecked.Balance)

Console.WriteLine("- - -")

Console.WriteLine("Below are all the accounts containing a balance greater than/equal to zero but less than £50:")
for accountBeingChecked in accountsWithALowBalance do
    Console.WriteLine("Bank Account Number: {0}, Current Balance: £ {1}", accountBeingChecked.AccountNumber, accountBeingChecked.Balance)
