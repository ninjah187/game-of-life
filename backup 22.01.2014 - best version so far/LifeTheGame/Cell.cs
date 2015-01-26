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
    class Cell : UIElement
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private static Grid mainGrid; //statyczne!!!! na dobrą sprawę pole jest niepotrzebne
        public Rectangle Rectangle { get; set; }
        public bool IsAlive { get; set; }
        //private SolidColorBrush backgroundBrush;

        public Cell(Grid mainGrid, int startRow, int startColumn)
        {
            Cell.mainGrid = mainGrid;
            this.Row = startRow;
            this.Column = startColumn;
            /*backgroundBrush = new SolidColorBrush()
            {
                Color = Color.FromArgb(255, 25, 25, 25)
            };*/
            Rectangle = new Rectangle()
            {
                Fill = Brushes.White
            };
            IsAlive = false;
        }

        public void MakeAlive()
        {
            IsAlive = true;
            Rectangle.Fill = Brushes.Black;
        }

        public void MakeDead()
        {
            IsAlive = false;
            //Rectangle.Fill = backgroundBrush;
            Rectangle.Fill = Brushes.White;
        }

        public void UpdateState(Cell[][] cells, int numberOfRows, int numberOfColumns)
        {
            short aliveNeighbors = CountNeighbors(cells, numberOfRows, numberOfColumns);
            switch (aliveNeighbors)
            {
                case 2:
                    {
                        if (this.IsAlive)
                        {
                            return;
                        }
                    } break;
                case 3:
                    {
                        if (this.IsAlive)
                        {
                            return;
                        }
                        else
                        {
                            MakeAlive();
                        }
                    } break;
                default:
                    {
                        if (this.IsAlive)
                        {
                            MakeDead();
                        }
                    } break;
            }
        }

        //decyduje, czy komorka bedzie w nastepnej turze zywa, czy martwa
        public bool Evolve(Cell[][] cells, int numberOfRows, int numberOfColumns)
        {
            short aliveNeighbors = NumberOfNeighbors(cells, numberOfRows, numberOfColumns);
            switch (aliveNeighbors)
            {
                case 2:
                    {
                        if (this.IsAlive)
                        {
                            return true;
                        }
                    } break;
                case 3:
                    {
                        if (this.IsAlive)
                        {
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                default:
                    {
                        if (this.IsAlive)
                        {
                            return false;
                        }
                    } break;
            }
            return false;
        }

        private short CountNeighbors(Cell[][] cells, int numberOfRows, int numberOfColumns)
        {
            short aliveNeighbors = 0;
            int i, j; //indeksy początkowe
            int k, l; //indeksy końcowe

            i = Row - 1; k = Row + 1;
            if (Row == 0)
            {
                i = 0;
            }
            if (Row == numberOfRows - 1)
            {
                k = Row;
            }

            j = Column - 1; l = Column + 1;
            if (Column == 0)
            {
                j = 0;
            }
            if (Column == numberOfColumns - 1)
            {
                l = Column;
            }
            int col = j;
            
            for (; i <= k; i++)
            {
                for (j = col; j <= l; j++)
                {
                    if (i == Row && j == Column)
                    {
                        continue;
                    }
                    if (cells[i][j].IsAlive)
                    {
                        aliveNeighbors++;
                        //testLabel.Content += " " + 0;
                    }
                    //cells[i][j].Rectangle.Fill = Brushes.Red;
                }
            }
            return aliveNeighbors;
        }

        private short NumberOfNeighbors(Cell[][] cells, int numberOfRows, int numberOfColumns)
        {
            short aliveNeighbors = 0;
            short rowTop = (short)(Row - 1); short rowCenter = (short)Row; short rowBottom = (short)(Row + 1);
            short columnLeft = (short)(Column - 1); short columnCenter = (short)Column; short columnRight = (short)(Column + 1);
            
            if (Row == 0)
            {
                rowTop = (short)(numberOfRows - 1);
            }
            if (Row == numberOfRows - 1)
            {
                rowBottom = 0;
            }

            if (Column == 0)
            {
                columnLeft = (short)(numberOfColumns - 1);
            }
            if (Column == numberOfColumns - 1)
            {
                columnRight = 0;
            }

            if (cells[rowTop][columnLeft].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowTop][columnCenter].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowTop][columnRight].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowCenter][columnLeft].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowCenter][columnRight].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowBottom][columnLeft].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowBottom][columnCenter].IsAlive)
            {
                aliveNeighbors++;
            }
            if (cells[rowBottom][columnRight].IsAlive)
            {
                aliveNeighbors++;
            }

            return aliveNeighbors;
        }
    }
}
