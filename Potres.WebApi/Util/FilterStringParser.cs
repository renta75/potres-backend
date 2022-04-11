using Potres.Contracting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Potres.WebApi.Util
{
  public class FilterStringParser
  {
    static string[] operators = new string[] { "=", "<", ">", ">=", "<=", "contains", "startswith", "endswidth" };
    static string regex;
    static FilterStringParser ()
    {
      StringBuilder sb = new StringBuilder("(");
      for(int i=0; i<operators.Length; i++)
      {
        if (i != 0)
        {
          sb.Append('|');          
        }
        sb.Append(@"\(");
        sb.Append(operators[i]);
        sb.Append(@"\)");
      }
      sb.Append(')');
      regex = sb.ToString();
    }
    public static List<Filter> Parse(string filterString)
    {
      if (string.IsNullOrWhiteSpace(filterString)) return null;

      List<Filter> list = new List<Filter>();
      string[] filters = filterString.Split(',');
      foreach (var filter in filters)
      {

        string[] triple = Regex.Split(filter, regex, RegexOptions.IgnoreCase);        
        if (triple.Length == 3)
        {          
          list.Add(new Filter(triple[0], triple[1].Substring(1, triple[1].Length - 2), triple[2]));
        }
      }
      return list;
    }
  }
}
