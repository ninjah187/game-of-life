using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    class Exploder : Structure
    {
        public Exploder(int row, int column, Cell[,] cells)
            :base(row, column, 4, 4, cells)
        {
            Initialize();
        }

        public override void Initialize()
        {
            cells[Row, Column].MakeAlive(); cells[Row, Column + 2].MakeAlive(); cells[Row, Column + 4].MakeAlive();
            cells[Row + 1, Column].MakeAlive(); cells[Row + 1, Column + 4].MakeAlive();
            cells[Row + 2, Column].MakeAlive(); cells[Row + 2, Column + 4].MakeAlive();
            cells[Row + 3, Column].MakeAlive(); cells[Row + 3, Column + 4].MakeAlive();
            cells[Row + 4, Column].MakeAlive(); cells[Row + 4, Column + 2].MakeAlive(); cells[Row + 4, Column + 4].MakeAlive();
        }
    }
}
