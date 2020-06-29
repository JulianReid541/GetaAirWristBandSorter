using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetAirWristBandSorter.Models
{
    public class ColorSheet
    {
        public string[] Colors = { "Red", "Blue", "Pink", "Purple", "Yellow", "Green", "Orange" };

        public string[] Times = { "10:30", "11:00", "11:30", "12:00",
                                  "12:30", "1:00", "1:30", "2:00",
                                  "2:30", "3:00", "3:30", "4:00",
                                  "4:30", "5:00", "5:30", "6:00",
                                  "6:30", "7:00", "7:30", "8:00",
                                  "8:30", "9:00", "9:30", "10:00",
                                  "10:30", "11:00", "11:30", "12:00" };

        public string[] OffColors = { "", "", "Red", "Blue", "Pink", "Purple", "Yellow", "Green", "Orange" };



        public List<string[]> CreateSheet() {
            List<string[]> timesColors = new List<string[]>();

            for (int i = 0, j = 0, k = 0; i < Times.Length; i++, j++, k++) {
                List<string> stringList = new List<string>();

                stringList.Add(Times[i]);

                if (j > Colors.Length - 1) {
                    j = 0;
                    stringList.Add(Colors[j]);
                }
                else
                    stringList.Add(Colors[j]);

                if (k > OffColors.Length - 1) {
                    k = 2;
                    stringList.Add(OffColors[k]);
                }
                else
                    stringList.Add(OffColors[k]);

                string[] arr = stringList.ToArray();

                timesColors.Add(arr);
            }

            return timesColors;
        }
    }
}