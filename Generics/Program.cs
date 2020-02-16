using System;
using System.Collections.Generic;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{
			int length = 5;
			#region Collection of ints
			GenericArray<int> collectionForInts = new GenericArray<int>(length);
			collectionForInts[0] = 1;
			collectionForInts[1] = 5;
			collectionForInts[2] = 10;
			Console.WriteLine($"Generic collection for ints of length { length }: ");
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine(collectionForInts[i]);
			}
			collectionForInts.Swap(0, 2);
			Console.WriteLine($"Generic collection for ints of length { length }: ");
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine(collectionForInts[i]);
			}
			#endregion
			#region Collection of strings
			GenericArray<string> collectionForStrings = new GenericArray<string>(length);
			collectionForStrings[0] = "Max";
			collectionForStrings[1] = "Vlad";
			Console.WriteLine($"Generic collection for strings of length { length }: ");
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine(collectionForStrings[i]);
			}
			#endregion

		}
	}

	class GenericArray<T>
	{
		private T[] arr;
		public int Length { get; private set; } = 0;
		public GenericArray(int length)
		{
			arr = new T[length];
			Length = length;
		}
		public T this[int i]
		{
			get
			{
				if (i < 0 || i > Length)
					throw new ArgumentOutOfRangeException("index");
				else
					return arr[i];
			}
			set
			{
				if (i < 0 || i > Length)
					throw new ArgumentOutOfRangeException("index");
				else
					arr[i] = value;
			}
		}
		public void Swap(int i1, int i2)
		{
			T tmp = arr[i1];
			arr[i1] = arr[i2];
			arr[i2] = tmp;
		}
	}
}
