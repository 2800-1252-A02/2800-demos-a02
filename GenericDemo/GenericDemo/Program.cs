using static System.Console;
namespace GenericDemo
{
  internal class Program
  {
    static void Main(string[] args)
    {
      { // extension method version
        List<double> dubs = [1.2, 2.4, 56.6];
        foreach (var item in dubs.enumerate())
        {
          WriteLine($"{item.ind} : {item.val}");
        }
      }
      { // old argument version
        List<char> dubs = ['A', 'C', 'Z'];
        foreach (var item in ExtLib.enumerate(dubs))
        {
          WriteLine($"{item.ind} : {item.val}");
        }
      }
    }
  }
}
