using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveRacersManager
{
    public static class Extensions
    {

        public static string ExtendedToString(this IEnumerable<Standing> list)
        {
            return String.Concat(list.Select(i => i.ToString() + Environment.NewLine));
        }
        public static string ReorderToString(this IEnumerable<Standing> list)
        {
            return String.Concat(list.Select(i => "/editgrid " + i.ToNewPosition() + Environment.NewLine));
        }
    }
}
