using System;
using System.Collections;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{
			int length = 5;

			Console.WriteLine("==== Use of generic array ====");

			#region Array of ints
			GenericArray<int> arrayOfInts = new GenericArray<int>(length);

			arrayOfInts[0] = 1;
			arrayOfInts[1] = 5;
			arrayOfInts[2] = 10;

			Console.WriteLine($"Array of ints of length { length }: ");
			PrintCollection(arrayOfInts);


			int i1 = 0;
			int i2 = 2;
			arrayOfInts.Swap(i1, i2);

			Console.WriteLine($"Array of ints of length { length } after swapping elements with i1 = { i1 }, i2 = { i2 }: ");
			PrintCollection(arrayOfInts);
			#endregion

			#region Array of strings
			GenericArray<string> arrayOfStrings = new GenericArray<string>(length);

			arrayOfStrings[0] = "Max";
			arrayOfStrings[1] = "Vlad";

			Console.WriteLine($"Array of strings of length { length }: ");
			PrintCollection(arrayOfStrings);
			#endregion



		}

		static void PrintCollection(IEnumerable c)
		{
			foreach (var item in c)
			{
				Console.Write($"{ item } ");
			}

			Console.WriteLine();
			Console.WriteLine();
		}
	}

	class GenericArray<T> : IEnumerable
	{
		private T[] arr;

		public int Length { get; private set; }

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
			if (i1 < 0 || i1 > Length)
			{
				throw new ArgumentOutOfRangeException("i1");
			}
			else if (i2 < 0 || i2 > Length)
			{
				throw new ArgumentOutOfRangeException("i2");
			}

			T tmp = arr[i1];
			arr[i1] = arr[i2];
			arr[i2] = tmp;
		}

		public IEnumerator GetEnumerator()
		{
			return arr.GetEnumerator();
		}
	}
}
