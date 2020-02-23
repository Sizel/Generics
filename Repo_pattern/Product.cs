using System;
using System.Collections.Generic;
using System.Text;

namespace Repo_pattern
{
	class Product : Entity
	{
		public Product(string name, int? price)
		{
			Name = name;
			Price = price;
		}

		public string Name { get; set; }
		public int? Price { get; set; }
	}
}
