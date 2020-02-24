using System;
using System.Collections.Generic;
using System.Text;

namespace CleaningRecords.Global
{
    public static class ZP
    {
      public static  Dictionary<int, string> RepeatDict = new Dictionary<int, string>
            {
             {0,"Never" },{1,"Every Week" },{2,"Every 2 Week" },{3,"Every 3 Week" },
             {4,"Every 4 Week" },{5,"Every 5 Week" },{6,"Every 6 Week" },
                {7,"Every 7 Week" },{8,"Every 8 Week" },
                };

        public static string Dbdir= "";
        public static string OldDbdir= "";
        public static string OldDb = "CleaningDb2.db";
        public static string Db = "CleaningDb3.db";


        public static string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    }
}
