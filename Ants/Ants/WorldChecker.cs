using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ants
{

    class WorldChecker
    {
        int counter;
        int arraySize = 0;
        bool Legal;
        int worldSizeY, worldSizeX;
        List<Array> worldLines = new List<Array>();
        WorldGeneration WG;
        String fp;

        public WorldChecker(WorldGeneration wg, String filePath)
        {
            WG = wg;
            fp = filePath;
        }
        public void go()
        {
            runCheck(fp);
            checkMap();
            drawTiles();
        }

        public void runCheck(String filePath) // do this method first once you create the worldChecker class
        {
            counter = 0;
            string lines;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath); // put whatever world in here

            while ((lines = file.ReadLine()) != null)
            {
                copyLinesIntoArray(lines);
                counter++;
            }
            file.Close();
        }

        public void copyLinesIntoArray(String line)
        {
            string lines = line;
            string[] chars = new string[500];
            int i = 0;
            string[] split = lines.Split(new Char[] { ' ' });

            foreach (string s in split)
            {

                if (s.Trim() != "")
                {
                    chars[i] = s;
                    i++;
                }

            }
            worldLines.Add(chars);
        }

        public void checkMap()  // run this method second, after run check
        {

            for (int i = 0; i < worldLines.Count(); i++)
            {
                arraySize = 0;
                string[] currentArray = (string[])worldLines[i];
                for (int j = 0; j < currentArray.Length; j++)
                {
                    if (currentArray.GetValue(j) != null)
                    {
                        if (i < 2) // check size of map, top 2 arrays, update values of x and y
                        {
                            if (j == 0)
                            {
                                try { worldSizeX = Convert.ToInt32(currentArray.GetValue(j)); }
                                catch { }
                            }
                            if (j == 1)
                            {
                                try { worldSizeY = Convert.ToInt32(currentArray.GetValue(j)); }
                                catch { }
                            }
                        }
                        else
                        {
                            // get the actual array size (pre declared array is not correct size)
                            arraySize++;
                        }
                    }
                }
            }
            checkSurround();
        }

        public void checkSurround()
        {
            Legal = true;
            for (int i = 2; i < worldLines.Count(); i++)
            {
                string[] currentArray = (string[])worldLines[i];
                for (int j = 0; j < arraySize; j++)
                {
                    Console.WriteLine(currentArray.GetValue(j));
                    if (i == 2 || i == worldLines.Count() - 1)
                    {
                        if ((string)currentArray.GetValue(j) != "#")
                        {
                            Legal = false;
                        }
                    }
                    if (j == arraySize - 1)
                    {
                        if ((string)currentArray.GetValue(j) != "#")
                        {
                            Legal = false;
                        }
                    }
                    if (j == 0)
                    {
                        if ((string)currentArray.GetValue(j) != "#")
                        {
                            Legal = false;
                        }
                    }

                }
            }
        }

        public bool getLegality() // if you want to know legality
        {
            return Legal;
        }

        public bool isSizeEqual() // returns true if numbers are the same for X & Y, else false. 
        {
            if (worldSizeX == worldSizeY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void drawTiles() // will draw whatever tile you wish depending on value
        {
            for (int i = 0; i < 150; i++)
            {
                string[] currentArray = (string[])worldLines[i+2];
                for (int j = 0; j < arraySize; j++)
                {
                    if ((string)currentArray.GetValue(j) == "#")
                    {
                        WG.setRocky(j, i);
                    }

                    else if ((string)currentArray.GetValue(j) == "-")
                    {
                        WG.setAntHill(j, i, "black");
                    }

                    else if ((string)currentArray.GetValue(j) == "+")
                    {
                        WG.setAntHill(j, i, "red");
                    }
                    else if ((string)currentArray.GetValue(j) == ".")
                    {
                        WG.setBlank(j, i);
                    }
                    else if ((string)currentArray.GetValue(j) == ".")
                    {
                        WG.setBlank(j, i);
                    }
                    else
                    {
                        try
                        {
                            int x = int.Parse((string)currentArray.GetValue(j));
                            if (x == 1)
                            {
                                WG.setFood(j, i, 1);
                            } if (x == 2)
                            {
                                WG.setFood(j, i, 2);
                            }
                            if (x == 3)
                            {
                                WG.setFood(j, i, 3);
                            } if (x == 4)
                            {
                                WG.setFood(j, i, 4);
                            } if (x == 5)
                            {
                                WG.setFood(j, i, 5);
                            } if (x == 6)
                            {
                                WG.setFood(j, i, 6);
                            } if (x == 7)
                            {
                                WG.setFood(j, i, 7);
                            } if (x == 8)
                            {
                                WG.setFood(j, i, 8);
                            } if (x == 9)
                            {
                                WG.setFood(j, i, 9);
                            }
                        }
                        catch { }
                    }

                }
            }
        }
    }

}

