using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestWays
{
    public class GameManager
    {
        public GameManager()
        {
            sizeX = map.GetLength(0);
            sizeY = map.GetLength(1);
        }
        char[,] map = {
            { 'S', 'x', 'x', 'x', 'x' },
            { '0', 'x', '0', '0', '0' },
            { '0', 'x', '0', '0', '0' },
            { '0', '0', '0', 'x', '0' },
            { 'x', '0', '0', '0', 'E' }
            };
        //    char[,] map = {
        //        { 'S', 'x', '0', '0', '0' },
        //        { '0', '0', '0', '0', '0' },
        //        { '0', '0', '0', '0', '0' },
        //        { '0', '0', '0', '0', '0' },
        //        { '0', '0', '0', '0', 'E' }
        //};
        int locX = 0, locY = 0;
        int sizeX = 0, sizeY = 0;
        public void MoveTO(string exp)
        {
            string[] commands = exp.Split(" ");
            foreach (var item in commands)
            {
                if (item.EndsWith("j"))
                {
                    MoveTO(Int32.Parse(item.Replace("j", "")), 0);
                }
                else if (item.EndsWith("i"))
                {
                    MoveTO(0, Int32.Parse(item.Replace("i", "")));
                }
            }
        }
        void MoveTO(int x, int y)
        {

            //move x
            for (int i = 0; i < Math.Abs(x); i++)
            {
                int alamat = x > 0 ? 1 : -1;
                if (locX + alamat >= 0 && locX + alamat < sizeX && map[locX + alamat, locY] != 'x')
                {
                    locX += alamat;
                }
                else
                {
                    throw new Exception("Unvalid Move in X");
                }
            }
            //move y
            for (int i = 0; i < Math.Abs(y); i++)
            {
                int alamat = y > 0 ? 1 : -1;
                if (locY + alamat >= 0 && locY + alamat < sizeY && map[locX, locY + alamat] != 'x')
                {
                    locY += alamat;
                }
                else
                {
                    throw new Exception("Unvalid Move in Y");
                }
            }


        }
        public bool isWon()
        {
            if (map[locX, locY] == 'E')
            {
                return true;
            }
            return false;
        }

    }
}
