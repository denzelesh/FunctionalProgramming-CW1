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

// Test the account type
let accountFunctionalityTest() =
    let newBankAccount = Account("123456789", 1000.0) // Creates an account using Account type
    newBankAccount.Print() // Outputs current account information to console
    newBankAccount.Withdrawal(350.0) // Withdrawl Test (Subtracts 350 from account balance)
    newBankAccount.Print() 
    newBankAccount.Deposit(200.0) // Deposit Money Test (Adds 200 to account balance)
    newBankAccount.Print() 
    newBankAccount.Withdrawal(5000.0) // Attempting a withdrawl amount higher than the money present in account.

accountFunctionalityTest()


