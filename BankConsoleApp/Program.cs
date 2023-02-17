
using System;
using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Db;
using BankConsoleApp.DataAccess.Repository;
using BankConsoleApp.Service.Accounts;

namespace BankConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            AccountsAppServices account = new AccountsAppServices();
            using (var db = new MySqlDbContext())
            {
                while (true)
                {
                    Console.WriteLine("Seleccione una opción:");
                    Console.WriteLine("1. Agregar cuenta");
                    Console.WriteLine("2. Realizar transacción");
                    Console.WriteLine("3. Salir");

                    int opcion;
                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine("Opción no válida.");
                        continue;
                    }

                    switch (opcion)
                    {
                        case 1: //ADD ACCOUNT
                            Console.Write("Nombre del propietario: ");
                            var owner = Console.ReadLine();

                            Console.Write("Tipo de cuenta: ");
                            var accountType = Console.ReadLine();
                            
                            if(string.IsNullOrEmpty(owner) && string.IsNullOrEmpty(accountType))
                            {
                                Console.WriteLine("\nNO PUEDE INGRESAR VALORES NULOS");
                                Console.Write("Nombre del propietario: ");
                                owner = Console.ReadLine();

                                Console.Write("Tipo de cuenta: ");
                                accountType = Console.ReadLine();
                                
                                continue;
                            }  

                            account.AddAccount(owner, accountType);
                            db.SaveChanges();

                            Console.WriteLine("Cuenta agregada correctamente.");
                            break;

                        case 2: //DO TRANSACTION

                            Console.Write("Monto: ");
                            if (!float.TryParse(Console.ReadLine(), out float amount))
                            {
                                Console.WriteLine("Monto no válido.");
                                continue;
                            }

                            Console.Write("Descripción: ");
                            var description = Console.ReadLine();
                            if (string.IsNullOrEmpty(description))
                            {
                                description = Console.ReadLine();
                                Console.WriteLine("Ingrese una descripción.");
                                continue;
                            }
                            account.AuthorizeTransaction(amount);
                            account.DoTransaction(amount, description);
                            db.SaveChanges();
                            Console.WriteLine("Transacción realizada correctamente.");
                                                                             
                            break;

                        case 3: //GET 
                            return;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }
        }
    }
}
