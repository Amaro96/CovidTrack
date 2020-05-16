using System;
using System.Collections.Generic;
using System.Text;

namespace XFCovidTrack.Helpers
{
   public static class TransformationsNumbers
    {
        public static string TransformationsNumbersCases(int number)
        {
            switch (number.ToString().Length)
            {
                case 1:
                case 2:
                case 3:
                    return number.ToString();
                case 4:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}k";
                case 5:
                    return $"{number.ToString().Insert(2, ",").Substring(0, 4)}k";
                case 6:
                    return $"{number.ToString().Insert(3, ",").Substring(0, 5)}k";
                default:
                    return $"{number.ToString().Insert(1, ",").Substring(0, 3)}m";
            }
        }
    }
}
