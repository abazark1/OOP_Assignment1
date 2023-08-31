using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment
{
	public class Menu
	{
		private Set myset = new Set();

		public Menu() { }

		public void Run() 
		{
			int n = 0;
			do
			{
				PrintMenu();
				try
				{
					n = int.Parse(Console.ReadLine()!);
				}
				catch (System.FormatException) { n = -1; }
				catch (System.OverflowException) { n = -1; }
			

				if (n > 7 || n < 0)
				{
					Console.WriteLine("There is no such operation to do. Choose numbers from 0 to 7");
				}
				else
				{
					switch (n)
					{
						case 1:
							AddElement();
							break;
						case 2:
							RemoveElement();
							break;
						case 3:
							PrintSet();
							break;
						case 4:
							EmptySet();
							break;
						case 5:
							ContainsElement();
							break;
						case 6:
							RandomElement();
							break;
						case 7:
							EvenElements();
							break;
					}
				}
			} while (n != 0);
		}

		static private void PrintMenu()
		{
			Console.WriteLine("\n\n--------------My program menu--------------");
			Console.WriteLine(" 0. Quit");
			Console.WriteLine(" 1. Add an element");
			Console.WriteLine(" 2. Remove an element");
			Console.WriteLine(" 3. Print the set");
			Console.WriteLine(" 4. Is the set empty?");
			Console.WriteLine(" 5. Check if an element is in the set");
			Console.WriteLine(" 6. Return random element");
			Console.WriteLine(" 7. Return the number of even elements");
			Console.WriteLine("-------------------------------------------");
			Console.Write(" Enter your choice: ");
			
		}

		private void AddElement()
		{
			int n = 0;
			bool ok = false;
			do
			{
				Console.Write("Give an element to add: ");
				try
				{	
					n = int.Parse(Console.ReadLine()!);
					ok = true;
				}
				catch (System.FormatException)
				{
					Console.WriteLine("Integer is expected!");
				}
				catch (System.OverflowException)
				{
					Console.WriteLine("The integer is too large or too small");
				}
			} while (!ok);

			if (myset.IsEmpty())
			{
				myset.InsertEl(n);
			} 
			else if (!myset.ContainsEl(n))
			{
				myset.InsertEl(n);
			}
			else
			{
				Console.WriteLine("This element is already in the set");
			}
		}

		private void RemoveElement()
		{
			int n = 0;
			bool ok = false;
	
			do
			{
				Console.Write("Give an element to remove: ");
				try
				{
					n = int.Parse(Console.ReadLine()!);
					ok = true;
				}
				catch (System.FormatException)
				{
					Console.WriteLine("Integer is expected!");
				}
				catch (System.OverflowException)
				{
					Console.WriteLine("The integer is too large or too small");
				}
			} while (!ok);

			try
			{
				if (myset.ContainsEl(n))
				{
					myset.RemoveEl(n);
				}
				else
				{
					Console.WriteLine("There's no such element to remove");
				}
			} 
			catch (Set.EmptySetException) 
			{
				Console.WriteLine("The set is empty, add elements first");
			}
		}

		private void PrintSet()
		{
			try
			{
				myset.PrintEl();
			}
			catch (Set.EmptySetException)
			{
				Console.WriteLine("The set is empty, add elements first");
			}
		}

		private void EmptySet()
		{
			if (myset.IsEmpty())
			{ 
				Console.WriteLine("The set is empty");
			}
			else
			{
				Console.WriteLine("The set is not empty");
			}
		}

		private void ContainsElement()
		{
			int n = 0;
			bool ok = false;
			
			do
			{
				Console.Write("Give an element to check if it is in the set: ");
				try
				{
					n = int.Parse(Console.ReadLine()!);
					ok = true;
				}
				catch (System.FormatException)
				{
					Console.WriteLine("Integer is expected!");
				}
				catch (System.OverflowException)
				{
					Console.WriteLine("The integer is too large or too small");
				}
				
			} while (!ok);

			try
			{
				if (myset.ContainsEl(n))
				{
					Console.WriteLine("The set contains this element");
				}
				else
				{
					Console.WriteLine("There is no such element in the set");
				}
			}
			catch (Set.EmptySetException)
			{
				Console.WriteLine("The set is empty, add elements first");
			}
		}

		private void RandomElement()
		{
			try
			{
				int n = myset.ReturnRandomEl();
				Console.WriteLine("Random element from the set: " + n);
			}
			catch (Set.EmptySetException)
			{
				Console.WriteLine("The set is empty, add elements first!");
			}
			
		}

		private void EvenElements()
		{
			try
			{
				int n = myset.EvenNums();
				Console.WriteLine("The number of even numbers in the set: " + n);
			}
			catch (Set.EmptySetException)
			{
				Console.WriteLine("The set is empty, add elements first!");
			}

		}
	}
}
