using System;
using System.Collections.Concurrent;
using System.Reflection.Metadata;

public class cardHoller
{
	string cardNum;
	int pin;
	string fristName;
	string lastName;
	double balance;

	public cardHoller(string cardNum, int pin, 
		string fristName, string lastName, double balance)
	{
		this.cardNum = cardNum;
		this.pin = pin;
		this.fristName = fristName;
		this.lastName = lastName;
		this.balance = balance;
	}

	public string getNum()
	{
		return cardNum;
	}

	public int getPin()
	{
		return pin;
	}

	public string getFristName()
	{
		return fristName;
	}

	public string getLastName()
	{
		return lastName;
	}

	public double getBalance()
	{
		return balance;
	}

	public void setNum(string newCardNum)
	{
		cardNum = newCardNum;
	}

	public void setPin(int newPin)
	{
		pin = newPin;
	}

	public void setFristName(string newFristName)
	{
		fristName = newFristName;
	}

	public void setLastName(string newLastName)
	{
		lastName = newLastName;
	}

	public void setBalance(double newBalance)
	{
		balance = newBalance;
	}

	public static void Main(String[] args)
	{
		void printOptions()
		{
            Console.WriteLine("Plase choose from one  of the fllowing options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

		void deposit(cardHoller currentUser)
		{
            Console.WriteLine("How much $$ would you like to deposit? ");
			double deposit = Double.Parse(Console.ReadLine());
			currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new Balance is: " + currentUser.getBalance());
        }

		void withdraw(cardHoller currentUser)
		{
            Console.WriteLine("How much $$ would you like to withdraw:");
			double withdrawal = Double.Parse(Console.ReadLine());
			// Chesk if the user  has enougt money
			if(currentUser.getBalance() > withdrawal)
			{
                Console.WriteLine("Insufficient balance :(");
            }
			else
			{
				currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
		}

		void balance(cardHoller currentUser)
		{
            Console.WriteLine("current balance :" + currentUser.getBalance());
        }

		List<cardHoller> cardHollers = new List<cardHoller>();
		cardHollers.Add(new cardHoller("4572772818527322", 1234, "Jhon", "Uik", 150.31));
		cardHollers.Add(new cardHoller("4562662881527394", 4321, "Ashley", "Jones", 321.13));
		cardHollers.Add(new cardHoller("4552182822520754", 9999, "Frida", "Dickerson", 105.59));
		cardHollers.Add(new cardHoller("4569745824357336", 2468, "Muneeb", "Harding", 851.84));
		cardHollers.Add(new cardHoller("4532652818527377", 4826, "Dawn", "Smith", 54.31));

        // Prompt user 
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Plase insert your debit card: ");
		string debitCardNum = "";
		cardHoller currentUser;

		while(true)
		{
			try
			{
				debitCardNum = Console.ReadLine();
				// Chesk agins our db
				currentUser = cardHollers.FirstOrDefault(a => a.cardNum == debitCardNum); 
			    
				if(currentUser != null) { break; }
				else { Console.WriteLine("Card not recognized. Please try agin "); }
			}
			catch { Console.WriteLine("Card not recognized. Please try agin "); }
		}

        Console.WriteLine("Please enter your pin");
		int userPin = 0;

        while (true)
		{
			try
			{
				userPin = int.Parse(Console.ReadLine());
				// Chesk agins our db
				if (currentUser.getPin() == userPin ) { break; }
				else { Console.WriteLine("Incorrect pin. Please try agin "); }
			}
			catch { Console.WriteLine("Incorrect pin. Please try agin "); }
		}

		Console.WriteLine("Welcome " + currentUser.getFristName() + " :) ");
		int option = 0;
		do
		{
			printOptions();
			try
			{
				option = int.Parse(Console.ReadLine());
			}
			catch { }
			if (option == 1) { deposit(currentUser); }
			else if (option == 2) { withdraw(currentUser); }
			else if(option == 3) { balance(currentUser); }
			else if (option == 4) { break; } 
			else { option = 0; }
		}
		while (option != 4);
		{
            Console.WriteLine("Thanl you! Have a nice day :) ");
        }

	}
}