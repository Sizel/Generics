using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Repo_pattern
{
	class ProductEqualityComparer : IEqualityComparer<Product>
	{
		public bool Equals([AllowNull] Product x, [AllowNull] Product y)
		{
			return GetHashCode(x) == GetHashCode(y);
		}

		public int GetHashCode([DisallowNull] Product obj)
		{
			byte[] bytesObj = ObjectToByteArray(obj);

			SHA256 mySHA = SHA256.Create();

			byte[] hash = mySHA.ComputeHash(bytesObj);

			return BitConverter.ToInt32(hash, 0);
		}

		private byte[] ObjectToByteArray(Object obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);

			return ms.ToArray();
		}
	}
}
