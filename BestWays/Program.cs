
using System;
using System.Collections;
using System.Diagnostics.Tracing;
using System.Drawing;


namespace BestWaysGame
{
    class Program
    {
        class gameMap
        {
            static char[,] map = {
            { 'S', '0', '0', 'x', '0' },
            { '0', '0', '0', '0', '0' },
            { '0', '0', 'x', 'x', '0' },
            { '0', '0', '0', '0', '0' },
            { '0', '0', '0', '0', 'E' }
            };

            static bool checkPath(int ip, int jp)      // checking the destination location
            {
                
                if (map[ip, jp] != 'x' && ip<map.GetLength(0) && jp< map.GetLength(1)) return true;
                else throw new Exception("out of bound or crashing to barrier");
            }

            public static bool iterateMap(string exprsn, char[,] map)        // to iterate the map based on inputs
            {
                int k = 0, i = 0, j = 0;
                string sNum = "";

                int num = 0;

                int IP = 0, JP = 0, endI = 0, endJ = 0; // these are used to determine the location of the player and the endpoint of the game

                bool sign = false;      // this is for signs '+' and '-'

                char[] ex = exprsn.ToCharArray();       // to store an expression in a char array for easier iteration.


                while (k < ex.Length) // used a while loop to iterate the map +44i
                {

                    if (ex[k] == '-')
                    {
                        sign = false;

                        k++;

                        if (char.IsDigit(ex[k]))
                        {
                            sNum += ex[k].ToString();
                            num = int.Parse(sNum);
                        }
                    }


                    if (ex[k] == 'i' && sign == false)
                    {
                        if (checkPath(i + num, j))      // to check the inputs so that they don't get out of the range of the map or crash into a barrier
                        {
                            map[i += num, j] = 'p';
                            num = 0;
                        }
                        else
                        {
                            return false;
                        }
 
                    }


                    if (ex[k] == 'j' && sign == false)
                    {
                        if (checkPath(i, j - num))      // to check the inputs so that they don't get out of the range of the map or crash into a barrier
                        {
                            map[i, j -= num] = 'p';
                            num = 0;
                        }
                        else
                        {
                            return false;
                        }

                    }


                    if (ex[k] == '+')
                    {
                        sign = true;
                        k++;
                        if (char.IsDigit(ex[k]))
                        {
                            num += int.Parse(ex[k].ToString());
                        }

                    }


                    if (ex[k] == 'i' && sign == true)
                    {
                        if (checkPath(i - num, j))      // to check the inputs so that they don't get out of the range of the map or crash into a barrier
                        {
                            map[i -= num, j] = 'p';
                            num = 0;
                        }
                        else
                        {
                            return false;
                        }

                    }


                    if (ex[k] == 'j' && sign == true)
                    {
                        if (checkPath(i, j + num))      // to check the inputs so that they don't get out of the range of the map or crash into a barrier
                        {
                            map[i, j += num] = 'p';
                            num = 0;
                        }
                        else
                        {
                            return false;
                        }

                    }

                    k++;
                }
                if (map[i, j] == map[4, 4]) return true;
                else return false;
            }

        }
        static void Main(string[] args)
        {
            char[,] map = {
            { 'S', '0', '0', 'x', '0' },
            { '0', '0', '0', '0', '0' },
            { '0', '0', 'x', 'x', '0' },
            { '0', '0', '0', '0', '0' },
            { '0', '0', '0', '0', 'E' }
            };
            Console.WriteLine( gameMap.iterateMap("+4j-4i",map));
        }
    }
}


/*namespace game
{
    class Path
    {
        public bool startFrom_i=true;
        public int i = 0, j = 0;

    }
    class bestWay
    {

    }
    class Program
    {
        public static bool checkPath(string exprsn, char[,] map)
        {
            int counter = 0;
            List<Path> pathes = new List<Path>();

            char[] c = exprsn.ToCharArray();

            Path path = new Path();

            int shomarandeh = 0;
            while (counter < c.Length )
            {

                
                if (char.IsDigit(c[counter]))
                {
                    if (shomarandeh % 2 == 0)
                    {
                        path = new Path();
                        pathes.Add(path);
                    }
                    if (c[counter + 1] == 'i')
                    {
                        path.i = int.Parse(c[counter].ToString());
                        
                        if (c[counter - 1] == '-')
                        {
                            path.i *= -1;
                        }
                        shomarandeh++;
                    }
                    else if (c[counter + 1] == 'j')
                    {
                        path.j = int.Parse(c[counter].ToString());
                        
                        if (c[counter - 1] == '-')
                        {
                            path.j *= -1;
                        }
                        shomarandeh++;
                        if (shomarandeh % 2 != 0)
                        {
                            path.startFrom_i = false;
                        }
                    }
                }
                counter++;
            }
            int startI = 0, startJ = 0, endI = map.Length, endJ = map.Length;
            while (pathes.Count >= 0)
            {
                int i = 0, j = 0, peymayeshI=0, peymayshJ=0;
                Path p = pathes[0];
                pathes.RemoveAt(0);
                i = path.i;j = path.j;
                if (path.startFrom_i)
                {
                    if (i < 0)
                    {
                        while (peymayeshI != i)
                        {
                            if (startI - 1 >= 0 && map[startI - 1, startJ] != 'x')
                            {
                                startI--;
                                peymayeshI--;
                            }
                            else return false;
                        }
                    }
                    else
                    {

                        while (peymayeshI != i)
                        {
                            if (startI + 1 <= map.Length - 1 && map[startI + 1, startJ] != 'x')
                            {
                                startI++;
                                peymayeshI++;
                            }
                            else return false;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            char[,] map = {
            { 's', '0', '0', 'x', '0' },
            { '0', '0', '0', '0', '0' },
            { '0', '0', 'x', 'x', '0' },
            { '0', '0', '0', '0', '0' },
            { '0', '0', '0', '0', 'E' }
        };

            //Console.WriteLine("Enter your expresion: ");
            checkPath("+3j-2i+1i+4j",map);
            //string exprsn = Console.ReadLine();
        }
    }
}*/