using System.ComponentModel;

namespace OOP_assignment
{
	public class Set
	{
		#region Exceptions
		public class EmptySetException : Exception { };
		#endregion


		#region Attribute
		private List<int> x = new();
		#endregion


		#region Constructors
		public Set() 
		{
			x = new List<int>();
		}

		public Set(Set set2)
		{
			for (int i = 0; i < set2.getSize(); i++)
			{
				InsertEl(set2.x[i]);
			}
		}
		#endregion


		#region Properties
		public int getSize()
		{
			return x.Count;
		}

		public int this[int index]
		{
			get
			{
				if (index < 0 || index > getSize()) throw new IndexOutOfRangeException();
				return x[index];
				//used for testing later
			}
		}

		public override string ToString()
		{
			string result = "";
			for (int i = 0; i < getSize(); i++)
			{
				result += string.Join(" ", x[i].ToString().Split("")) + "\n";
			}
			return result;
		}
		#endregion


		#region Operations
		public void InsertEl(int k)
		{
			if (getSize() == 0)
			{
				x.Insert(0, k);
			}
			else if (!ContainsEl(k))
			{
				//Insertion sort algorithm
				int ind = 0;
				while(ind < getSize() && x[ind] < k)
				{
					ind++;
				}
				x.Insert(ind,k);
			}
			PrintEl();
			
		}

		public void RemoveEl(int k)
		{
			if (getSize() == 0)
			{
				throw new EmptySetException();
			}
			else
			{
				x.Remove(k);
				PrintEl();
			}
		}

		public bool IsEmpty()
		{
			if (getSize() == 0)
			{
				return true;
			}
			return false;
		}

		public bool ContainsEl(int k)
		{
			if (IsEmpty()) throw new EmptySetException();

			//Linear search algorithm
			for (int i = 0; i < getSize(); i++)
			{
				if ((x[i] == k))
				{
					return true;
				}
			}
			return false;
		}

		public int ReturnRandomEl()
		{
			if (IsEmpty()) throw new EmptySetException();

			Random r = new Random();
			return x[r.Next(0, getSize() - 1)];
		}

		public int EvenNums()
		{
			if (getSize() == 0) throw new EmptySetException();

			//Counting algorithm
			int count = 0;
			for (int i = 0; i < getSize(); i++)
			{
				if (x[i] % 2 == 0)
				{
					count += 1;
				}
			}
			return count;
		}

		public void PrintEl()
		{
			for (int i = 0; i < getSize(); i++)
			{
				Console.WriteLine(x[i]);
			}
		}

		#endregion
	}
}