using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
  public static class ExtLib
  {
    public static IEnumerable<(int ind, T val)> enumerate<T>( this IEnumerable<T> lst )
    {
      List<(int ind, T val)> result = new();
      
      int index = 0;
      foreach (T item in lst)
        result.Add(( index++, item ));
      return result;
    }
  }
}
