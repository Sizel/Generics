using System;
using System.Collections.Generic;
using System.Text;

namespace Repo_pattern
{
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
