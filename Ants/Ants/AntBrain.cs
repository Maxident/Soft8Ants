using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ants
{
    class AntBrain
    {
        BrainChecker BC;
        AntCommand[] commands;
        Ant[] ants;
        Logic myLogic;

        public AntBrain(String FilePath, Ant[] Ants, Logic MyLogic)
        {
            BC = new BrainChecker(FilePath);
            BC.runCheck();
            commands = BC.getCommands();
            ants = Ants;
            myLogic = MyLogic;
            for (int i = 0; i < 10000; i++)
            {
                if (commands[i] == null)
                {
                    commands[i] = new AntCommand("flip", "1", "0", "0", null, null);
                }
            }
        }
        public void executeCommand(int AntID)
        {
            if (ants[AntID].getResting())
            {
                ants[AntID].setRestingNum(ants[AntID].getRestingNum() - 1);
                if (ants[AntID].getRestingNum() == 0)
                {
                    ants[AntID].setResting(false);
                }
            }
            else
            {
                AntCommand nextCom = commands[ants[AntID].state];
                if (nextCom.get(0).ToLower().Equals("sense"))
                {
                    if (nextCom.get(4).ToLower().Equals("friend"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getAnt() && ants[AntID].sense(nextCom.get(1)).getColour().ToLower().Equals(ants[AntID].colour.ToLower()))
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    else if (nextCom.get(4).ToLower().Equals("friendwithfood"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getAnt() && ants[AntID].sense(nextCom.get(1)).getColour().ToLower().Equals(ants[AntID].colour.ToLower())
                            && myLogic.getAntOnTile(ants[AntID].sense(nextCom.get(1)).getTilePos("x"), ants[AntID].sense(nextCom.get(1)).getTilePos("y")).hasFood())
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("foewithfood"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getAnt() && !ants[AntID].sense(nextCom.get(1)).getColour().ToLower().Equals(ants[AntID].colour.ToLower())
                            && myLogic.getAntOnTile(ants[AntID].sense(nextCom.get(1)).getTilePos("x"), ants[AntID].sense(nextCom.get(1)).getTilePos("y")).hasFood())
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("food"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getFood())
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("rock"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getRocky())
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("marker"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getPheremone(ants[AntID].colour) > 0)
                        {
                            int markerCheck = -1;
                            try
                            {
                                markerCheck = Convert.ToInt32(nextCom.get(5));
                            }
                            catch { }
                            if (markerCheck == ants[AntID].sense(nextCom.get(1)).getPheremone(ants[AntID].colour))
                            {
                                try
                                {
                                    ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("foemarker"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getColour() != null)
                        {
                            if (ants[AntID].sense(nextCom.get(1)).getColour().ToLower().Equals(ants[AntID].colour))
                            {
                                try
                                {
                                    ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("home"))
                    {
                        Tile newTile = ants[AntID].sense(nextCom.get(1));
                        if (ants[AntID].sense(nextCom.get(1)).getAntHill()  && ants[AntID].sense(nextCom.get(1)).getColour().ToLower().Equals(ants[AntID].colour))
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                    if (nextCom.get(4).ToLower().Equals("foehome"))
                    {
                        if (ants[AntID].sense(nextCom.get(1)).getAntHill() && !ants[AntID].sense(nextCom.get(1)).getColour().ToLower().Equals(ants[AntID].colour))
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                ants[AntID].state = Convert.ToInt32(nextCom.get(3));
                            }
                            catch { }
                        }
                    }
                }
                else if (nextCom.get(0).ToLower().Equals("mark"))
                {
                    int marker = -1;
                    try
                    {
                        marker = Convert.ToInt32(nextCom.get(1));
                    }
                    catch{}
                    myLogic.getTile(ants[AntID].x, ants[AntID].y).setPheremone(ants[AntID].colour, marker);
                    try
                    {
                        ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                    }
                    catch { }
                }
                else if (nextCom.get(0).ToLower().Equals("unmark"))
                {
                    int marker = -1;
                    myLogic.getTile(ants[AntID].x, ants[AntID].y).setPheremone(ants[AntID].colour, marker);
                    try
                    {
                        ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                    }
                    catch { }
                }
                else if (nextCom.get(0).ToLower().Equals("pickup"))
                {
                    if (ants[AntID].hasFood())
                    {
                        try
                        {
                            ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                        }
                        catch { }
                    }
                    else if (!ants[AntID].hasFood() && myLogic.getTile(ants[AntID].x, ants[AntID].y).getFood())
                    {
                        ants[AntID].pickUpFood();
                        try
                        {
                            ants[AntID].state = Convert.ToInt32(nextCom.get(1));
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                        }
                        catch { }
                    }
                }
                else if (nextCom.get(0).ToLower().Equals("drop"))
                {
                    ants[AntID].dropFood();
                    try
                    {
                        ants[AntID].state = Convert.ToInt32(nextCom.get(1));
                    }
                    catch { }
                }
                else if (nextCom.get(0).ToLower().Equals("turn"))
                {
                    ants[AntID].turn(nextCom.get(1).ToLower());
                    try
                    {
                        ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                    }
                    catch { }
                }
                else if (nextCom.get(0).ToLower().Equals("move"))
                {
                    if (ants[AntID].sense("ahead").rocky)
                    {
                        try
                        {
                            ants[AntID].state = Convert.ToInt32(nextCom.get(2));
                        }
                        catch { }
                    }
                    else
                    {
                        ants[AntID].move();
                        ants[AntID].setResting(true);
                        ants[AntID].setRestingNum(14);
                        try
                        {
                            ants[AntID].state = Convert.ToInt32(nextCom.get(1));
                        }
                        catch { }
                    }
                }
                else if (nextCom.get(0).ToLower().Equals("flip"))
                {
                    int p = -1, st1 = -1, st2 = -1;
                    try
                    {
                        p = Convert.ToInt32(nextCom.get(1));
                        st1 = Convert.ToInt32(nextCom.get(2));
                        st2 = Convert.ToInt32(nextCom.get(3));
                    }
                    catch { }
                    ants[AntID].flip(p, st1, st2);
                }

            }

        }
    }
}
