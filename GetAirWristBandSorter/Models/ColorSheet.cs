using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GetAirWristBandSorter.Models
{
    public class ColorSheet
    {
        //default arry values for Colors, Times, and OffColors
        public string[] Colors = { "Red/Paw", "Blue/Smiley", "Pink/Wow", "Purple/Dino", "Yellow/Wow", "Green/Paw", "Orange/Elephant" };

        public string[] Times = { "10:30", "11:00", "11:30", "12:00",
                                  "12:30", "1:00", "1:30", "2:00",
                                  "2:30", "3:00", "3:30", "4:00",
                                  "4:30", "5:00", "5:30", "6:00",
                                  "6:30", "7:00", "7:30", "8:00",
                                  "8:30", "9:00", "9:30", "10:00",
                                  "10:30", "11:00", "11:30", "12:00" };

        public string[] OffColors = { "", "", "Red/Paw", "Blue/Smiley", "Pink/Wow", "Purple/Dino", "Yellow/Wow", "Green/Paw", "Orange/Elephant" };


        //creates board using default values
        public List<string[]> CreateSheet() {
            //create new list of string arrays
            List<string[]> timesColors = new List<string[]>();

            //for loop i goes through times array, j goes through colors array. k goes through off colors array
            for (int i = 0, j = 0, k = 0; i < Times.Length; i++, j++, k++) {
                //creates list
                List<string> stringList = new List<string>();

                //adds current time element to the list
                stringList.Add(Times[i]);

                //if j is greater than colors length restart from the beginning of array or just add the element to the list
                if (j > Colors.Length - 1) {
                    j = 0;
                    stringList.Add(Colors[j]);
                }
                else
                    stringList.Add(Colors[j]);

                //if k is greater than offcolors length restart from the second element of array or just add the element to the list
                if (k > OffColors.Length - 1) {
                    k = 2;
                    stringList.Add(OffColors[k]);
                }
                else
                    stringList.Add(OffColors[k]);

                // convert looped list to array
                string[] arr = stringList.ToArray();

                //add the array to timesColors list
                timesColors.Add(arr);
            }

            //OUTPUT
            //timesColors list
            //[0] = {"10:30", "Red/Paw", ""}
            //[1] = {"11:00", "Blue/Smiley",""}
            return timesColors;
        }

        //shuffles elements in current board randomly
        public void Shuffle() {
            Random gen = new Random();
            for (int i = 0, j = 2; i < Colors.Length; i++, j++) {
                int rnd = gen.Next(i, Colors.Length);
                string c = Colors[rnd];
                Colors[rnd] = Colors[i];
                Colors[i] = c;

                OffColors[j] = Colors[i];
            }
        }
    }
}