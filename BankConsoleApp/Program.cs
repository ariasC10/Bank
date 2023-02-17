
using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Db;
using BankConsoleApp.DataAccess.Repository;
using BankConsoleApp.Service.Accounts;
using System.Formats.Asn1;


var sistema = new AccountsAppServices(new AccountRepository(new MySqlDbContext()));

bool salir = false;


Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
Console.WriteLine("\r\n░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░  ██████╗░░█████╗░███╗░░██╗██╗░░██╗\r\n░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗  ██╔══██╗██╔══██╗████╗░██║██║░██╔╝\r\n░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║  ██████╦╝███████║██╔██╗██║█████═╝░\r\n░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║  ██╔══██╗██╔══██║██║╚████║██╔═██╗░\r\n░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝  ██████╦╝██║░░██║██║░╚███║██║░╚██╗\r\n░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝");
Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");

do
{
    Console.WriteLine("\nMenu options:");
    Console.WriteLine("1: Create an account");
    Console.WriteLine("2: Choose an account to enter");
    Console.WriteLine("3: Exit");

    string option = Console.ReadLine();
    switch (option)
    {
        // Create account process
        case "1":
            Console.WriteLine("\nType the account owner name :");
            string name = Console.ReadLine();

            Console.WriteLine("Type the account type :");
            string accounType = Console.ReadLine();

            sistema.AddAccount(name,accounType);
            break;
            

        // Choose account process
        case "2":
            Console.WriteLine("\nEnter the account number :");
            uint accountNumber = uint.Parse(Console.ReadLine());

            sistema.SelectAccount(accountNumber);
               
            bool salirSubMenu = false;

            do
            {
                // Actions to the account choosen
                Console.WriteLine("\n♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
                Console.WriteLine("Options Submenu");
                Console.WriteLine("Number Account: " + accountNumber);
                Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");

                Console.WriteLine("1: Make a deposit");
                Console.WriteLine("2: Make a withdrawal");
                Console.WriteLine("3: Show balance");
                Console.WriteLine("4: Exit");


                string option2 = Console.ReadLine();
                switch (option2)
                {
                    // Make a deosit process
                    case "1":
                        Console.WriteLine("Type a amount to deposit :");
                        float amount = (float)Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Type the description of the transaction :");
                        string description = Console.ReadLine();

                        sistema.DoTransaction(amount, description);
                        break;
                        
                    // Make a withdrawal process
                    case "2":
                        Console.WriteLine("Type a amount to withdraw :");
                        float amountWithdraw = (float)Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Type the description of the transaction");
                        string descriptionWithdraw = Console.ReadLine();

                        sistema.DoTransaction(-amountWithdraw, descriptionWithdraw);
                        break;


                    // Show balance process
                    case "3":
                        sistema.GetBalanace();
                        break;


                    // Exit process
                    case "4":
                        salirSubMenu = true;
                        break;


                    default:
                        Console.WriteLine("▲ Type a valid option ▲");
                        break;
                }

            } while (salirSubMenu == false);
            break;


        // Exit process
        case "3":
            salir = true;
            break;


        default:
            Console.WriteLine("▲ Type a valid option ▲");
            break;
    }

} while (salir == false);
