using OOP_assignment;

namespace SetTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestAdd()
		{
			Set set = new Set();
			Assert.AreEqual(0, set.getSize());

			set.InsertEl(5);
			Assert.AreEqual(1, set.getSize());

			set.InsertEl(3);
			Assert.AreEqual(3, set[0]);

			set.InsertEl(3);
			Assert.AreEqual(2, set.getSize());
			Assert.AreEqual(3, set[0]);
			Assert.AreNotEqual(3, set[1]);

		}

		[TestMethod]
		public void TestRemove()
		{
			Set set1 = new Set();
			try
			{
				set1.RemoveEl(1);
				Assert.Fail("No exception thrown");
			}
			catch (Exception e)
			{
				Assert.IsTrue(e is Set.EmptySetException);
			}

			set1.InsertEl(2);
			set1.InsertEl(3);
			Assert.IsTrue(set1.ContainsEl(2));

			set1.RemoveEl(2);
			Assert.IsTrue(!set1.ContainsEl(2));
		}

		[TestMethod]
		public void TestEmpty()
		{
			Set set2 = new Set();
			Assert.IsTrue(set2.IsEmpty());

			set2.InsertEl(1);
			Assert.IsTrue(!set2.IsEmpty());

			set2.RemoveEl(1);
			Assert.IsTrue(set2.IsEmpty());
		}

		[TestMethod]
		public void TestContains()
		{
			Set set3 = new Set();
			try
			{
				set3.ContainsEl(1);
				Assert.Fail("No exception thrown");
			}
			catch (Exception e)
			{
				Assert.IsTrue(e is Set.EmptySetException);
			}

			set3.InsertEl(3);
			set3.InsertEl(4);
			Assert.IsTrue(set3.ContainsEl(3));
			Assert.IsTrue(set3.ContainsEl(4));
			Assert.IsFalse(set3.ContainsEl(5));
		}

		[TestMethod]
		public void TestRandom()
		{
			Set set4 = new Set();
			try
			{
				set4.ReturnRandomEl();
				Assert.Fail("No exception thrown");
			}
			catch (Exception e)
			{
				Assert.IsTrue(e is Set.EmptySetException);
			}

			set4.InsertEl(5);
			set4.InsertEl(6);
			set4.InsertEl(7);
			int rand1 = set4.ReturnRandomEl();
			Assert.IsTrue(set4.ContainsEl(rand1));
			Assert.AreNotEqual(4, set4.ReturnRandomEl());
		}

		[TestMethod]
		public void TestEven()
		{
			Set set5 = new Set();
			try
			{
				set5.EvenNums();
				Assert.Fail("No exception thrown");
			}
			catch (Exception e)
			{
				Assert.IsTrue(e is Set.EmptySetException);
			}

			set5.InsertEl(5);
			set5.InsertEl(6);
			set5.InsertEl(4);
			Assert.AreEqual(2, set5.EvenNums());
			set5.RemoveEl(4);
			Assert.AreEqual(1, set5.EvenNums());

		}
	}
}