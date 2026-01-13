using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
  public static class ExtLib
  {
    private static Random _rnd = new Random();

    // generate the desired number of unique numbers
    // number range is upper exclusive 2 x the requested number
    //  so, an argument of 4 would have the range (2 * 4) [0-7]
    //  4 unique values returned in that range
    public static IEnumerable<int> GenerateNums(int iNum)
    {
      if (iNum < 0)
        throw new ArgumentException("ExtLib:GenerateNums:Invalid range");
      return Enumerable.Range(0,iNum);
    }

    /// <summary>
    /// enumerate - return a collection of tuples matching the source
    /// collection, but including the relative position
    /// </summary>
    /// <typeparam name="T">collection type</typeparam>
    /// <param name="lst">source collection</param>
    /// <returns>collection of named tuple</returns>
    public static IEnumerable<(int ind, T val)> enumerate<T>(this IEnumerable<T> lst)
    {
      List<(int ind, T val)> result = new();

      int index = 0;
      foreach (T item in lst)
        result.Add((index++, item));
      return result;
    }
    /// <summary>
    /// denumerate - variant of enumerate using a temporary collection
    /// to allow indexing of the source collection
    /// Interestingly - can be faster than enumerate due to the
    /// faster indexing access, rather than using foreach() overhead
    /// </summary>
    /// <typeparam name="T">collection type</typeparam>
    /// <param name="lst">source collection</param>
    /// <returns>collection of named tuple</returns>
    public static IEnumerable<(int ind, T val)> denumerate<T>(this IEnumerable<T> lst)
    {
      List<T> tmpList = lst.ToList(); // temporary List - copy
      List<(int ind, T val)> result = new(); // result list

      for (int i = 0; i < tmpList.Count; i++)
        // indexing is fast, the underlying structure is array
        result.Add((i, tmpList[i])); 
      return result;
    }
  }
}
