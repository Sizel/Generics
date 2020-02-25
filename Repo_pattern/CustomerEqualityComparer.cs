using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Repo_pattern
{
	class CustomerEqualityComparer : IEqualityComparer<Customer>
	{
		public bool Equals([AllowNull] Customer x, [AllowNull] Customer y)
		{
			return GetHashCode(x) == GetHashCode(y);
		}

		public int GetHashCode([DisallowNull] Customer obj)
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
