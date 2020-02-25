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
	class Product : Entity
	{
		public string Name { get; set; }
		public int? Price { get; set; }

		public Product(string name, int? price)
		{
			Name = name;
			Price = price;
		}

	}
	
}
