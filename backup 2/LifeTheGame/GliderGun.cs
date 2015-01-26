using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    public enum Directions { Left, Top, Right, Bottom }

    class GliderGun : Structure
    {
        private Directions Direction;

        public GliderGun(int row, int column, Cell[,] cells, Directions Direction)
            :base(row, column, 38, 11, cells)
        {
            this.Direction = Direction;
            Initialize();
        }

        public override void Initialize()
        {
            switch (Direction)
            {
                case Directions.Right:
                    {
                        cells[Row + 1, Column + 25].MakeAlive();
                        cells[Row + 2, Column + 23].MakeAlive();
                        cells[Row + 2, Column + 25].MakeAlive();
                        new Block(Row + 3, Column + 21, cells);
                        cells[Row + 5, Column + 21].MakeAlive();
                        cells[Row + 5, Column + 22].MakeAlive();
                        cells[Row + 6, Column + 23].MakeAlive();
                        cells[Row + 6, Column + 25].MakeAlive();
                        cells[Row + 7, Column + 25].MakeAlive();
                        new Block(Row + 6, Column + 1, cells);
                        new Block(Row + 4, Column + 35, cells);

                        cells[Row + 3, Column + 13].MakeAlive();
                        cells[Row + 3, Column + 14].MakeAlive();
                        cells[Row + 4, Column + 12].MakeAlive();
                        cells[Row + 4, Column + 16].MakeAlive();
                        cells[Row + 5, Column + 11].MakeAlive();
                        cells[Row + 5, Column + 17].MakeAlive();
                        cells[Row + 6, Column + 11].MakeAlive();
                        cells[Row + 6, Column + 15].MakeAlive();
                        cells[Row + 6, Column + 17].MakeAlive();
                        cells[Row + 6, Column + 18].MakeAlive();
                        cells[Row + 7, Column + 11].MakeAlive();
                        cells[Row + 7, Column + 17].MakeAlive();
                        cells[Row + 8, Column + 12].MakeAlive();
                        cells[Row + 8, Column + 16].MakeAlive();
                        cells[Row + 9, Column + 13].MakeAlive();
                        cells[Row + 9, Column + 14].MakeAlive();
                    } break;
            }
        }
    }
}
