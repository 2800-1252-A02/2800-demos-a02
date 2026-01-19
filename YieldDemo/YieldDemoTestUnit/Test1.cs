// Remember to add the Dependancy -> Project, YieldDemo[]
using YieldDemo;

namespace YieldDemoTestUnit
{
  class RefThing
  {
    public string Name { get; set; }
    public RefThing(string name)
    {
      Name = name;
    }
    override public string ToString() // Not required for this test, but useful for debugging
    {
      return Name;
    }
  }
  [TestClass]
  public sealed class OddsOnly
  {
    [TestMethod]
    public void empty()
    {
      List<int> numbers = new();
      var result = numbers.GetOdds();
      Assert.AreEqual(0, result.Count());
    }
    [TestMethod]
    public void MoreThanFive()
    {
      List<RefThing> items = new()
      {
        new RefThing("Zero"),
        new RefThing("One"), // This one
        new RefThing("Two"),
        new RefThing("Three"), // This three
        new RefThing("Four"),
        new RefThing("Five"), // This five
        new RefThing("Six"),
      };
      // Since we are comparing references, we can use CollectionAssert.AreEqual, it will use ReferenceEquals since we
      // did not override Equals() in RefThing
      CollectionAssert.AreEqual(
        new List<RefThing> { items[1], items[3], items[5] }, // expected
        items.GetOdds().ToList() // actual - it must be ToList() to force evaluation
      );
    }
  }
}
