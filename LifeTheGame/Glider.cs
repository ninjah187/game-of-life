using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    public enum GliderDirections { LeftTop, RightTop, LeftBottom, RightBottom }

    class Glider : Structure
    {
        private GliderDirections Direction;

        public Glider(int row, int column, Cell[,] cells, GliderDirections dir)
            :base(row, column, 3, 3, cells)
        {
            this.Direction = dir;
            Initialize();
        }

        override public void Initialize()
        {
            switch (Direction)
            {
                case GliderDirections.LeftTop:
                    {
                        GlideLeftTop();
                    } break;
                case GliderDirections.RightTop:
                    {
                        GlideRightTop();
                    } break;
                case GliderDirections.LeftBottom: 
                    {
                        GlideLeftBottom();
                    } break;
                case GliderDirections.RightBottom:
                    {
                        GlideRightBottom();
                    } break;
            }
        }

        private void GlideLeftTop() 
        {
            cells[Row, Column].MakeAlive();
            cells[Row, Column + 1].MakeAlive();
            cells[Row, Column + 2].MakeAlive();
            cells[Row + 1, Column].MakeAlive();
            cells[Row + 2, Column + 1].MakeAlive();
        }

        private void GlideRightTop()
        {
            cells[Row, Column].MakeAlive();
            cells[Row, Column + 1].MakeAlive();
            cells[Row, Column + 2].MakeAlive();
            cells[Row + 1, Column + 2].MakeAlive();
            cells[Row + 2, Column + 1].MakeAlive();
        }

        private void GlideLeftBottom()
        {
            cells[Row, Column + 1].MakeAlive();
            cells[Row + 1, Column].MakeAlive();
            cells[Row + 2, Column].MakeAlive();
            cells[Row + 2, Column + 1].MakeAlive();
            cells[Row + 2, Column + 2].MakeAlive();
        }

        private void GlideRightBottom()
        {
            cells[Row, Column + 1].MakeAlive();
            cells[Row + 1, Column + 2].MakeAlive();
            cells[Row + 2, Column].MakeAlive();
            cells[Row + 2, Column + 1].MakeAlive();
            cells[Row + 2, Column + 2].MakeAlive();
        }

    }
}
