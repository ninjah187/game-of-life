using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LifeTheGame
{
    class Block : Structure
    {
        public Block(int row, int column, Cell[,] cells) 
            :base(row, column, 2, 2, cells)
        {
            Initialize();
        }

        override public void Initialize()
        {
            int x = Row + Width;
            int y = Column + Height;
            for (int i = Row; i < x; i++)
            {
                for (int j = Column; j < y; j++) 
                {
                    cells[i, j].MakeAlive();
                }
            }
        }

        /*public override void Evolve()
        {
            /*int x = Row + Width + 1;
            int y = Column + Height + 1;
            for (int i = Row - 1; i < x; i++)
            {
                for (int j = Column - 1; j < y; j++)
                {
                    cells[i][j].UpdateState(cells);
                }
            }*/
        /*    int x = Row + Width;
            int y = Column + Height;
            for (int i = Row; i < x; i++)
            {
                for (int j = Column; j < y; j++)
                {
                    cells[i][j].UpdateState(cells);
                }
            }
        }*/

    }
}
