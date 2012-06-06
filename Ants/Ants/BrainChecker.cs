using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ants
{
    class BrainChecker
    {
        AntCommand[] commands;
        int commandCounter;
        int counter;
        String filePath;

        public BrainChecker(String FP)
        {
            filePath = FP;
        }



        public void runCheck()
        {
            counter = 0; commandCounter = 0;
            commands = new AntCommand[10000];
            string lines;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);


            while ((lines = file.ReadLine()) != null)
            {
                Console.WriteLine(lines);
                commandCheck(lines);
                counter++;
            }
            file.Close();

            // Suspend the screen.
            //Console.ReadLine();
        }

        public void commandCheck(String sepLines)
        {
            string[] input = sepLines.Split(' ');

            // SENSE COMMAND
            if (input[0].Equals("Sense"))
            {
                if (isDirection(input[1]))
                {
                    isI(input[2]);
                    isI(input[3]);

                    if (isCondition(input[4], input))
                    {
                        if(input[4].ToLower().Equals("marker"))
                        {
                            commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), input[3].ToLower(), input[4].ToLower(), input[5].ToLower());
                            commandCounter++;
                        }
                        else
                        {
                            commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), input[3].ToLower(), input[4].ToLower(), null);
                            commandCounter++;
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("Condition Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Direction Incorrect, line " + counter);
                }
            }

            // MARK COMMAND 
            else if (input[0].Equals("Mark"))
            {
                if (isI(input[1]))
                {
                    if (isSt(input[2]))
                    {
                        commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), null, null, null);
                        commandCounter++;
                    }
                    else
                    {
                        throw new System.ArgumentException("Mark Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Mark Incorrect, line " + counter);
                }
            }

            else if (input[0].Equals("Unmark"))
            {
                if (isI(input[1]))
                {
                    if (isSt(input[2]))
                    {
                        commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), null, null, null);
                        commandCounter++;
                    }
                    else
                    {
                        throw new System.ArgumentException("Mark Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Mark Incorrect, line " + counter);
                }
            }


            else if (input[0].Equals("Pickup"))
            {
                if (isSt(input[1]))
                {
                    if (isSt(input[2]))
                    {
                        commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), null, null, null);
                        commandCounter++;
                    }
                    else
                    {
                        throw new System.ArgumentException("Pickup Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Pickup Incorrect, line " + counter);
                }
            }


            else if (input[0].Equals("Drop"))
            {
                if (isSt(input[1]))
                {
                    commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), null, null, null, null);
                    commandCounter++;
                }
                else
                {
                    throw new System.ArgumentException("Drop Incorrect, line " + counter);
                }
            }


            else if (input[0].Equals("Turn"))
            {
                if (isTurn(input[1]))
                {
                    if (isSt(input[2]))
                    {
                        commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), null, null, null);
                        commandCounter++;
                    }
                    else
                    {
                        throw new System.ArgumentException("Turn Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Turn Incorrect, line " + counter);
                }
            }


            else if (input[0].Equals("Move"))
            {
                if (isSt(input[1]))
                {
                    if (isSt(input[2]))
                    {
                        commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), null, null, null);
                        commandCounter++;
                    }
                    else
                    {
                        throw new System.ArgumentException("Move Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Move Incorrect, line " + counter);
                }
            }


            else if (input[0].Equals("Flip"))
            {
                if (isP(input[1]))
                {
                    if (isSt(input[2]))
                    {
                        if (isSt(input[3]))
                        {
                            commands[commandCounter] = new AntCommand(input[0].ToLower(), input[1].ToLower(), input[2].ToLower(), input[3].ToLower(), null, null);
                            commandCounter++;
                        }
                        else
                        {
                            throw new System.ArgumentException("Turn Number 2 Incorrect, line " + counter);
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("Turn Number 1 Incorrect, line " + counter);
                    }
                }
                else
                {
                    throw new System.ArgumentException("Flip Incorrect, line " + counter);
                }
            }
        }


        public bool isDirection(String direction)
        {
            if (direction.Equals("Here") || direction.Equals("Ahead") || direction.Equals("LeftAhead") || direction.Equals("RightAhead"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isP(String number)
        {
            Boolean isNum = false;
            try
            {
                int num = Convert.ToInt32(number);
                if (num >= 0)
                {
                    isNum = true;
                }
            }
            catch (FormatException e)
            {

                Console.WriteLine("Invalid Number Transformation on second sense number, line " + counter);
            }
            return isNum;
        }

        public bool isCondition(String condition, String[] input)
        {
            if (condition.Equals("Friend") || condition.Equals("Foe") || condition.Equals("FoeWithFood") || condition.Equals("FriendWithFood")
                || condition.Equals("Food") || condition.Equals("Rock") || condition.Equals("FoeMarker") || condition.Equals("Home") || condition.Equals("FoeHome"))
            {
                return true;
            }
            else if (condition.Equals("Marker"))
            {
                if (isI(input[5]))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool isTurn(String turn)
        {
            if (turn.Equals("Left") || turn.Equals("Right"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isI(String number)
        {
            Boolean isNum = false;
            try
            {
                int num = Convert.ToInt32(number);
                if (num < 6 && num >= 0)
                {
                    isNum = true;
                }
            }
            catch (FormatException e)
            {

                Console.WriteLine("Invalid Number Transformation on second sense number, line " + counter);
            }
            return isNum;
        }

        public bool isSt(String number)
        {
            Boolean isNum = false;
            try
            {
                int num = Convert.ToInt32(number);
                if (num < 10000 && num >= 0)
                {
                    isNum = true;
                }
            }
            catch (FormatException e)
            {

                Console.WriteLine("Invalid Number Transformation on second sense number, line " + counter);
            }
            return isNum;
        }
        public AntCommand[] getCommands()
        {
            return commands;
        }
    }
}
