using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    class Immortal : Structure
    {
        public Immortal(int row, int column, Cell[][] cells)
            :base(row, column, 5, 5, cells)
        {
            Initialize();
        }

        public override void Initialize()
        {
            cells[Row][Column].MakeAlive(); cells[Row][Column + 1].MakeAlive(); cells[Row][Column + 2].MakeAlive(); cells[Row][Column + 4].MakeAlive();
            cells[Row + 1][Column].MakeAlive();
            cells[Row + 2][Column + 3].MakeAlive(); cells[Row + 2][Column + 4].MakeAlive();
            cells[Row + 3][Column + 1].MakeAlive(); cells[Row + 3][Column + 2].MakeAlive(); cells[Row + 3][Column + 4].MakeAlive();
            cells[Row + 4][Column].MakeAlive(); cells[Row + 4][Column + 2].MakeAlive(); cells[Row + 4][Column + 4].MakeAlive();
        }
    }
}
