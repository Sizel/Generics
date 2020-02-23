using System;
using System.Collections;
using System.Collections.Generic;

namespace Repo_pattern
{
	class Repo_pattern
	{
		private static Random rnd = new Random();
		static void Main(string[] args)
		{
			IGenericRepo<Customer> customersRepo = new ListGenericRepo<Customer>();

			List<string> names = new List<string>() { "Max", "Vlad", "Andrei", "John" };

			#region Adding to repo
			Console.WriteLine("==== Adding 5 customers to customers repo ====");
			for (int i = 0; i < 5; i++)
			{
				customersRepo.Add(new Customer(names[rnd.Next(0, 4)], true, (CustomerType?)rnd.Next(0, 2)));
			}

			var customers = customersRepo.GetAll();

			PrintCollection(customers);
			#endregion

			#region Getting a customer from repo by ID and modifying him
			int id = 0;

			Console.WriteLine($"==== Get customer with ID = { id } and change his name to Vasilii ====");

			Customer c3 = customersRepo.GetById(id);
			c3.Name = "Vasilii";

			PrintCollection(customers);
			#endregion

			#region Deleting from repo
			Console.WriteLine($"==== Get customers after removing customer: { c3.ID }, { c3.Name }");
			customersRepo.Remove(c3);

			customers = customersRepo.GetAll();

			PrintCollection(customers);
			#endregion

			#region Count customers per type using dictionary
			Dictionary<CustomerType?, int> customersPerType = new Dictionary<CustomerType?, int>();
			customersPerType[CustomerType.Basic] = 0;
			customersPerType[CustomerType.Discount] = 0;

			foreach (var customer in customers)
			{
				if (customer.CustomerType.HasValue)
				{
					customersPerType[customer.CustomerType]++;
				}
			}

			foreach (var type in customersPerType)
			{
				Console.WriteLine($"{ type.Key }, { type.Value }");
			}
			#endregion

			Customer c = new Customer("fre", true, CustomerType.Basic);


			//ListGenericRepo<Product> products = new ListGenericRepo<Product>();

			Product p = new Product("fre", 4);
		}

		static void PrintCollection(IEnumerable c)
		{
			foreach (var item in c)
			{
				Console.WriteLine($"{ item } ");
			}
			Console.WriteLine();
		}
	}
}
