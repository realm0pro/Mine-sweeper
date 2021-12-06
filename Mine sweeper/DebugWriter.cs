using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_sweeper
{
    public static class DebugWriter
    {
        public static void Log<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine($"item{i} {list[i]}");
            }
        }
    }
}
