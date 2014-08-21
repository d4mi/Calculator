using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public static class Config
    {
        public static int StackSize { get; set; }
        public static string DateFormat { get; set; }

        static Config()
        {
            StackSize = 4;
            DateFormat = "yyyy.MM.dd";
        }
    }
}
