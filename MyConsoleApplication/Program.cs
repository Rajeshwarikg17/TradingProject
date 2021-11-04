using ApplicationDAL;
using ApplicationEntities;
using System;

namespace MyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            Console.WriteLine("WELCOME TO MINI PROJECT\n");
            do
            {


                Console.WriteLine("\nChoose the options below");
                Console.WriteLine("\n 1.Add Customer\n 2.Add Supplier\n 3.Show all Customers\n 4.Show all Suplliers\n 5.Export a Customer\n 6. Export a Supplier\n 7.Exit\n");

                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("You have chosen Add Customer : Please fill the below details");
                        AddCustomer();
                        break;
                    case 2:
                        Console.WriteLine("You have chosen Add Supplier : Please fill the below details");
                        AddSupplier();
                        break;
                    case 3:
                        Console.WriteLine("You have chosen to get all customers : ");
                        GetAllCustomers();
                        break;
                    case 4:
                        Console.WriteLine("You have chosen to get all suppliers : ");
                        GetAllSuppliers();
                        break;
                    case 5:
                        Console.WriteLine("You have chosen to Export a customer by giving ID : ");
                        SaveFileCustomer();
                        break;
                    case 6:
                        Console.WriteLine("You have chosen to Export a Supplier by giving ID : ");
                        SaveFileSupplier();
                        break;
                    case 7:
                        Console.WriteLine("Thank you\n");
                        break;
                    default:
                        break;
                }
            } while (input != 7);

      
        }

        private static void AddCustomer()
        {
            Customer c1 = new Customer();
            Console.Write("Enter a Trading partner Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            c1.TradingPartnerId = id;

            Console.Write("Enter a Trading partner Name : ");
            string name = (Console.ReadLine());
            c1.TradingPartnerName = name;

            Console.Write("Enter a City Name : ");
            string city = (Console.ReadLine());
            c1.City = city;

            Console.Write("Enter a Credit Limit : ");
            int credit = Convert.ToInt32(Console.ReadLine());
            c1.CreditLimit = credit;

            Console.Write("Enter a Email Id : ");
            string email = (Console.ReadLine());
            c1.EmailId = email;

            
            var errors= c1.Validate();
            if(errors.Count == 0)
            {
                DALService.SaveCustomerDetails(c1);
                Console.WriteLine("Customer details are saved to dB");
            }
            else
            {
                Console.WriteLine("\n Validation failed. Please find the below errors : \n");
                foreach( string err in errors)
                {
                    Console.WriteLine(err);
                }
            }
            
        }

        private static void AddSupplier()
        {
            Supplier s1 = new Supplier();
            Console.Write("Enter a Trading partner Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            s1.TradingPartnerId = id;

            Console.Write("Enter a Trading partner Name : ");
            string name = (Console.ReadLine());
            s1.TradingPartnerName = name;

            Console.Write("Enter a City Name : ");
            string city = (Console.ReadLine());
            s1.City = city;

            Console.Write("Enter a Credit Balance : ");
            int credit = Convert.ToInt32(Console.ReadLine());
            s1.CreditBalance = credit;

            Console.Write("Enter a Pan Number : ");
            string email = (Console.ReadLine());
            s1.PanNo = email;


            var errors = s1.Validate();
            if (errors.Count == 0)
            {
                DALService.SaveSupplierDetails(s1);
                Console.WriteLine("Supplier details are saved to dB");
            }
            else
            {
                Console.WriteLine("\n Validation failed. Please find the below errors : \n");
                foreach (string err in errors)
                {
                    Console.WriteLine(err);
                }
            }

        }

        private static void GetAllCustomers()
        {
            var customers = DALService.GetAllCustomers();
            Console.WriteLine("{TradingPartnerId}\t{TradingPartnerName}\t{City}\t{CreditLimit}\t{EmailId}");

            foreach (var cus in customers)
            {
                Console.WriteLine($"{cus.TradingPartnerId}\t{cus.TradingPartnerName}\t{cus.City}\t{cus.CreditLimit}\t{cus.EmailId}");
            }

        }
        private static void GetAllSuppliers()
        {
            var customers = DALService.GetAllSuppliers();
            Console.WriteLine("{TradingPartnerId}\t{TradingPartnerName}\t{City}\t{CreditLimit}\t{EmailId}");

            foreach (var sup in customers)
            {
                Console.WriteLine($"{sup.TradingPartnerId}\t{sup.TradingPartnerName}\t{sup.City}\t{sup.CreditBalance}\t{sup.PanNo}");
            }

        }

        private static void SaveFileCustomer()
        {
            string path = @"D:\Customer\Cust.txt";
            Console.WriteLine("Enter a ID to export to file");
            int id = Convert.ToInt32(Console.ReadLine());
            Customer c = DALService.GetCustomerById(id);
            c.SaveToFile(path);

        }

        private static void SaveFileSupplier()
        {
            string path = @"D:\Customer\Supp.txt";
            Console.WriteLine("Enter a ID to export to file");
            int id = Convert.ToInt32(Console.ReadLine());
            Supplier s = DALService.GetSupplierById(id);
            path= path.Replace("Supp", s.TradingPartnerName);

            s.SaveToFile(path);

        }
    }
}
