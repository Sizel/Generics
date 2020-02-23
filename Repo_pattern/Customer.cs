using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Repo_pattern
{
	class Customer : Entity, IEqualityComparer<Customer>
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

		public bool Equals([AllowNull] Customer x, [AllowNull] Customer y)
		{
			if (x == null && y == null)
			{
				return true;
			}
			else if (x == null || y == null)
			{
				return false;
			}
			else if (x.Equals(y.Name) && x.IsLoyal == y.IsLoyal && x.CustomerType == y.CustomerType)
			{
				return true;
			}
			else
				return false;
		}

		public int GetHashCode([DisallowNull] Customer obj)
		{
			
		}
	}
}
