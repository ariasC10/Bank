
using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Db;
using BankConsoleApp.DataAccess.Repository;
using BankConsoleApp.Service.Accounts;
using System.Formats.Asn1;

Console.WriteLine("Hello, World!");

var sistema = new AccountsAppServices(new AccountRepository(new MySqlDbContext()));

bool salir = false;


Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
Console.WriteLine("\r\n░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░  ██████╗░░█████╗░███╗░░██╗██╗░░██╗\r\n░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗  ██╔══██╗██╔══██╗████╗░██║██║░██╔╝\r\n░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║  ██████╦╝███████║██╔██╗██║█████═╝░\r\n░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║  ██╔══██╗██╔══██║██║╚████║██╔═██╗░\r\n░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝  ██████╦╝██║░░██║██║░╚███║██║░╚██╗\r\n░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝");
Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
Console.WriteLine("\n");
do
{
puntoInicial:

    Console.WriteLine("Menu options:");
    Console.WriteLine("1: Create an account");
    Console.WriteLine("2: Choose an account to enter");
    Console.WriteLine("3: Finish the program");
    Console.WriteLine("\n");
    

    string option = Console.ReadLine();
    switch (option)
    {
        case "1": //CREATE AN ACCOUNT
            Console.WriteLine();
            Console.WriteLine("Type the account owner name: ");

            string name = Console.ReadLine();

            Console.WriteLine("Type the account type: ");

            string accounType = Console.ReadLine();

           
            sistema.AddAccount(name,accounType);

            Console.WriteLine("The Account was created succesfully ☺☺☺ ");
            
            Thread.Sleep(2000);

            break;



        case "2": //CHOOSE AN ACCOUNT TO ENTER

            if (sistema.respositoryEmpty())
            {
                Console.WriteLine("There's no accounts");
            }
            else
            {
                //Show the accounts with the owner name and account number
                sistema.showAccounts();

                Console.WriteLine("Type an account number to enter");


                int accountNumber = 0;

                //validate the acount number entered
                for (int i = 0; i < 4; i++)
                {
                    if (i == 3)
                    {
                        Console.WriteLine("the number of maximum attempts has expired. Returning to the Main Menu");
                        goto puntoInicial;
                    }

                    try
                    {
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException e) 
                    {
                    }

                    if (accountNumber.GetType() == typeof(int) && sistema.SelectAccount((uint)accountNumber))
                    {
                        break;
                    }
                    {
                        Console.WriteLine("The value entered is not valid. Type again");
                    }                    
                }

               


                bool salirSubMenu = false;

                do
                {

                    // Actions to the account choosen

                    Console.WriteLine("\n");
                    Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
                    Console.WriteLine("Options Subenu");
                    Console.WriteLine("Number Account: " + accountNumber);
                    Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
                    Console.WriteLine("\n");

                    Console.WriteLine("1: Make a deposit");
                    Console.WriteLine("2: Make a withdrawal");
                    Console.WriteLine("3: Show balance");
                    Console.WriteLine("4: Show transactions");
                    Console.WriteLine("5: Back");


                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":

                            Console.WriteLine("Type a amount to deposit");

                            float amount = 0;


                            for (int i = 0; i < 4; i++)
                            {
                                if (i == 3)
                                {
                                    Console.WriteLine("the number of maximum attempts has expired. Returning to the Main Menu");
                                    goto puntoInicial;
                                }

                                try
                                {
                                    amount = (float)Convert.ToDouble(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                }

                                if (amount.GetType() == typeof(float) && amount > 0)
                                {
                                    break;
                                }
                                {
                                    Console.WriteLine("▲ The value entered is not valid. Type again ▲");
                                }
                            }
                            Console.WriteLine("Type the description of the transaction");
                            string description = Console.ReadLine();

                            sistema.DoTransaction(amount, description);
                            break;


                        case "2":

                            Console.WriteLine("Type a amount to withdraw");

                            float amountWithdraw = 0;


                            //Validating the input
                            for (int i = 0; i < 4; i++)
                            {
                                if (i == 3)
                                {
                                    Console.WriteLine("the number of maximum attempts has expired. Returning to the Main Menu");
                                    goto puntoInicial;
                                }

                                try
                                {
                                     amountWithdraw = (float)Convert.ToDouble(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                }

                                if (amountWithdraw.GetType() == typeof(float) && amountWithdraw > 0 )
                                {
                                    break;
                                }
                                {
                                    Console.WriteLine("▲ The value entered is not valid. Type again ▲");
                                }
                            }

                            Console.WriteLine("Type the description of the transaction");
                            string descriptionWithdraw = Console.ReadLine();

                            amountWithdraw = amountWithdraw * -1;
                            sistema.DoTransaction(amountWithdraw, descriptionWithdraw);

                            Thread.Sleep(2000);
                            break;

                        case "3":
                            Console.WriteLine("\n");
                            sistema.GetBalanace(accountNumber);
                            Console.WriteLine("\n");
                            break;

                        case "4":
                            Console.WriteLine("\n");
                            Console.WriteLine("Transactions of the account: " +accountNumber );
                            sistema.showTransactions();
                            Console.WriteLine("\n");
                            break;
                        case "5":
                            salirSubMenu = true;
                            break;
                        default:
                            Console.WriteLine("▲ Type a valid option ▲");
                            break;
                    }

                } while (salirSubMenu == false);

            }
            break;


        case "3": //EXIT
            salir = true;
            break;
        default:
            Console.WriteLine("Type a valid option");
            break;
    }

} while (salir == false);