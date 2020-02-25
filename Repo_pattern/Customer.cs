using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Repo_pattern
{
	[Serializable]
	class Customer : Entity
	{
		public string Name { get; set; }
		public bool? IsLoyal { get; set; }
		public CustomerType? CustomerType { get; set; }
		
		public Customer(string name, bool? isLoyal, CustomerType? customerType)
		{
			Name = name;
			IsLoyal = isLoyal;
			CustomerType = customerType;
		}

		public override string ToString()
		{
			return $"Name: { Name }, Is loyal: { IsLoyal }, Type: { CustomerType } ({ ID })";
		}
	}
}
