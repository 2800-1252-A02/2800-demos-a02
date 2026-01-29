// SelectMany Demo - See bottom of file for TestObj class

// List of TestObj which contains a internal exposed collection we want to extract,
//  - so NESTED DATA is what we want
var hierarchicalCollection = new List<TestObj>
{
    new TestObj { Items = new List<string> { "Item1", "Item2" }, Name = "t1" },
    new TestObj { Items = new List<string> { "Item3", "Item4" }, Name = "t2" }
};

// SelectMany() version with just key selector, here we want the Items collection of
//  each TestObj, where Select() would return us a collection of List<string> a nested collection,
//  SelectMany() will "flatten" all the lists of lists into a single collection of our nested type (string)
IEnumerable<string> flattenedCollection = hierarchicalCollection.SelectMany(t => t.Items);
foreach (var str in flattenedCollection)
  Console.WriteLine(str);

// The result is a single IEnumerable<string> containing:
// "Item1", "Item2", "Item3", "Item4"
Console.WriteLine();

// Use an overload with a result selector function
//   key selector still picks the nested collection, but the resultant selector gets
//   a tuple with the parent object AND child collection item
// You get to pick what you want in the result, here a tuple of parent:child pairs, combined to a string.
var flattenedWithParent = hierarchicalCollection.SelectMany(
    t => t.Items, // Collection selector
    (parent, child) => $"Parent Name {parent.Name} : {child} " // Result selector
);

foreach (var str in flattenedWithParent)
  Console.WriteLine(str);

// The result is an IEnumerable<string> containing:
// "t1 : Item1", "t1 : Item2", "t2 : Item3", "t2 : Item4"

Console.WriteLine();

var stringAsCollection = "I WonDer What TomorRow will BRING to ME ? A puppy mAybe ?";
Console.WriteLine($"Using : \u001b[43m\u001b[34m{stringAsCollection}\u001b[0m, grouping by isUpper() return : ");

// Group by the bool return of each char being uppercase, note the t/f nature of the grouping in output.
foreach ( var groupItem in stringAsCollection.GroupBy( ch => char.IsUpper(ch)))
{
  Console.Write($"Group Key : {groupItem.Key} : ");
  foreach (var item in groupItem) // Yes each groupItem is iterable and holds the matching items for the key
    Console.Write($"{item}"); // each char that matched the key selector true/false was uppercase
  Console.WriteLine();
}
Console.WriteLine();


class TestObj
{
  public string Name { get; set; }
  public List<string> Items { get; set; }
}

