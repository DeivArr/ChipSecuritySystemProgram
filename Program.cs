using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ColorChip> colorList = new List<ColorChip>();
            colorList.Add(new ColorChip(Color.Blue, Color.Yellow));
            colorList.Add(new ColorChip(Color.Red, Color.Green));
            colorList.Add(new ColorChip(Color.Orange, Color.Purple));
            colorList.Add(new ColorChip(Color.Yellow, Color.Yellow));
            colorList.Add(new ColorChip(Color.Yellow, Color.Blue));
            colorList.Add(new ColorChip(Color.Blue, Color.Red));
            colorList.Add(new ColorChip(Color.Yellow, Color.Red));

            List<ColorChip> finalList = new List<ColorChip>();
            for (int i = 0; i < colorList.Count; i++)
            {
                //find blue and build from there
                if (colorList[i].StartColor == Color.Blue)
                {
                    List<ColorChip> auxList = new List<ColorChip>();
                    auxList = colorList;

                    var item = colorList[i];
                    auxList.RemoveAt(i);
                    auxList.Insert(0, item);

                    int greenPosition = 0;

                    for (int j = 0; j < auxList.Count; j++)
                    {
                        for (int z = j + 1; z < auxList.Count; z++)
                        {
                            if (z < auxList.Count)
                            {
                                if (auxList[j].EndColor == auxList[z].StartColor)
                                {
                                    var auxItem = auxList[z];
                                    auxList.RemoveAt(z);
                                    auxList.Insert(j + 1, auxItem);

                                    if (auxList[j + 1].EndColor == Color.Green)
                                        greenPosition = j + 1;
                                    break;
                                }

                            }

                        }
                    }

                    //if no green position is found then leave the list empty 
                    if (greenPosition != 0)
                    {
                        //pick the longest list
                        auxList.RemoveRange(greenPosition + 1, auxList.Count - (greenPosition + 1));
                        if (finalList.Count < auxList.Count)
                        {
                            finalList.Clear();
                            finalList.AddRange(auxList);
                        }
                    }

                }
            }

            if (finalList.Count != 0)
            {
                Console.WriteLine("Longest valid List:");
                for (int n = 0; n < finalList.Count; n++)
                {
                    Console.WriteLine(finalList[n]);
                }
            }
            else
                Console.WriteLine("No valid lists found");
        }
    }
}
