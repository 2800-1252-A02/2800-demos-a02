using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldDemo
{
  public static class ExtLib
  {
    /// <summary>
    /// Finite Generator that yields only the odd-indexed items from the input collection.
    /// </summary>
    /// <typeparam name="T">Any type, no constraints</typeparam>
    /// <param name="items">Collection of T</param>
    /// <returns>yields odd item vlaue</returns>
    public static IEnumerable<T> GetOdds<T>(this IEnumerable<T> items)
    {
      int index = 0;
      foreach (T item in items) // no var yet !
      {
        if (index % 2 == 1)
        {
          yield return item; // yield only odd indexed items
        }
        index++;
      }
    }
  }
}
