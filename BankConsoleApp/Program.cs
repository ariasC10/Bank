
using System;
using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Db;
using BankConsoleApp.DataAccess.Repository;

namespace BankConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
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
                        case 1:
                            Console.Write("Tipo de cuenta: ");
                            var accountType = Console.ReadLine();

                            Console.Write("Propietario: ");
                            var owner = Console.ReadLine();

                            Console.Write("Saldo inicial: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
                            {
                                Console.WriteLine("Saldo no válido.");
                                continue;
                            }

                            db.AddAccount(owner, accountType);
                            db.SaveChanges();

                            Console.WriteLine("Cuenta agregada correctamente.");
                            break;

                        case 2:
                            Console.Write("Número de cuenta: ");
                            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
                            {
                                Console.WriteLine("Número de cuenta no válido.");
                                continue;
                            }

                            Console.Write("Monto: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                            {
                                Console.WriteLine("Monto no válido.");
                                continue;
                            }

                            Console.Write("Descripción: ");
                            var description = Console.ReadLine();

                            var success = db.DoTransaction(accountNumber, amount, description);
                            if (success)
                            {
                                db.SaveChanges();
                                Console.WriteLine("Transacción realizada correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Error al realizar la transacción.");
                            }

                            break;

                        case 3:
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
