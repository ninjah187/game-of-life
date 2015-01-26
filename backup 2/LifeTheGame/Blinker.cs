using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    class Blinker : Structure
    {
        public Blinker(int row, int column, Cell[,] cells)
            :base(row, column, 1, 5, cells)
        {
            Initialize();
        }

        override public void Initialize()
        {
            cells[Row, Column].MakeAlive();
            cells[Row + 1, Column].MakeAlive();
            cells[Row + 2, Column].MakeAlive();
            //cells[Row + 3][Column].MakeAlive();
            //cells[Row + 4][Column].MakeAlive();
        }
    }
}
