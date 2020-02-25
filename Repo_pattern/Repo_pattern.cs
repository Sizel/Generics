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

			#region Adding to repo
			Console.WriteLine("==== Adding 5 customers to customers repo ====");

			List<string> names = new List<string>() { "Max", "Vlad", "Andrei", "John" };
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

			Console.WriteLine("==== Customers per type ====");

			foreach (var type in customersPerType)
			{
				Console.WriteLine($"Number of customers of type { type.Key } : { type.Value }");
			}
			#endregion

			ListGenericRepo<Product> productsRepo = new ListGenericRepo<Product>();

			#region Adding products to repo
			List<Product> productsToAdd = new List<Product>() 
			{
				new Product("Product 1", 100),
				new Product("Product 2", 150),
				new Product("Product 3", 115)
			};

			foreach (var product in productsToAdd)
			{
				productsRepo.Add(product);
			}
			#endregion

			#region Getting products from repo and adding them to dictionary, providing equality comparer for products
			List<Product> productsFromRepo = productsRepo.GetAll();

			Dictionary<Product, int> sells = new Dictionary<Product, int>(new ProductEqualityComparer());
			
			sells.Add(productsFromRepo[0], 10);
			sells.Add(productsFromRepo[1], 20);
			sells.Add(productsFromRepo[2], 30);

			sells.Add(new Product("Product 1", 100), 30); // Error, because there is already a product with this values in dict
			#endregion
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
