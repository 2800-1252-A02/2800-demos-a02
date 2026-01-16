using GenericDemo;
using System.Diagnostics;

namespace GenericDemoTest // Name not relevant, pick one
{
  [TestClass]
  public sealed class GenerateNums // this should be the function name to be tested
  {
    [TestMethod]
    public void InvalidArgTest() // What is being verified
    {
      // Not relevant for this specific test, but an example of using
      //   a test user defined NON-TestMethod
      Num one = new();
      Assert.ThrowsException<ArgumentException>(() => ExtLib.GenerateNums(-1));
      Assert.ThrowsException<ArgumentException>(() => ExtLib.GenerateNums(-1));
      Assert.ThrowsException<ArgumentException>(() => ExtLib.GenerateNums(-1));
      Trace.WriteLine("Exception Tests");
    }
    [TestMethod]
    public void BigRangeCount()
    {
      {
        Assert.AreEqual(1000, ExtLib.GenerateNums(1000).Count());
        Trace.WriteLine("1000 count test.");
      }
      {
        CollectionAssert.AreEqual(
          Enumerable.Range(0, 1000).ToList(),
          ExtLib.GenerateNums(1000).ToList()); // Are these 2 sequences Equal ?
        Trace.WriteLine("1000 sequence test.");
      }
    }
    [TestMethod]
    public void AverageTest()
    {
      Trace.WriteLine("Average Test");
      // Included the delta, values must not vary more than the delta or FAIL
      // Yes this test fails intentionally ! Examine the output.
      Assert.AreEqual( 500, ExtLib.GenerateNums(1000).Average(), 0.1 );
    }
  }

  class Num
  {
    //ctor
    // over Equals
    // over GetHashCode
  }
}
