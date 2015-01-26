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
using System.Windows.Threading;

namespace LifeTheGame
{
    class Game
    {
        private Grid mainGrid;
        private int numberOfRows;
        private int numberOfColumns;
        private Cell[,] cells;
        private List<Structure> structures;
        public static List<Cell> aliveCells;
        public static List<Cell> toLive;
        public static List<Cell> toDie;

        private DispatcherTimer timer;

        public Game(Grid mainGrid)
        {
            this.mainGrid = mainGrid;
            numberOfRows = (int)mainGrid.Height / 10;
            numberOfColumns = (int)mainGrid.Width / 10;
            aliveCells = new List<Cell>();
            toLive = new List<Cell>();
            toDie = new List<Cell>();
            InitializeGrid();
            //structures = new List<Structure>();
            

            //Block b = new Block(0, 0, cells);
            //Glider g = new Glider(10, 10, cells);
            //Blinker bl = new Blinker(20, 20, cells);
            /*Exploder e = new Exploder(15, 20, cells);
            new Exploder(15, 40, cells);
            Glider g = new Glider(50, 60, cells, GliderDirections.LeftTop);
            new Glider(50, 50, cells, GliderDirections.LeftTop);
            new Exploder(15, 100, cells);
            new Exploder(15, 80, cells);
            new Glider(40, 60, cells, GliderDirections.RightTop);
            new Glider(40, 70, cells, GliderDirections.RightTop);*/
            //new Immortal(30, 30, cells);
            //new Immortal(30, 90, cells);
            //new Immortal(60, 60, cells);
            //new GliderGun(0, 0, cells, Directions.Right);
            new Block(40, 40, cells);
            new Immortal(45, 60, cells);
            //new Exploder(45, 60, cells);// new Exploder(45, 80, cells); new Exploder(45, 40, cells);
            //50, 60 55, 65 //55, 55
            /*Glider g2 = new Glider(35, 45, cells);
            new Glider(57, 47, cells);
            new Glider(52, 52, cells);
            new Glider(47, 57, cells);*/

            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 500) //50 ms
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            /*bool[,] lives = new bool[numberOfRows, numberOfColumns];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    lives[i, j] = cells[i][j].Evolve(cells, numberOfRows, numberOfColumns);
                }
            }
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (lives[i, j])
                    {
                        cells[i][j].MakeAlive();
                    }
                    else
                    {
                        cells[i][j].MakeDead();
                    }
                }
            }*/
            foreach (Cell c in aliveCells)
            {
                c.Evolve(true);
            }
            foreach (Cell c in toLive)
            {
                c.MakeAlive();
            }
            foreach (Cell c in toDie)
            {
                c.MakeDead();
            }
            toLive.Clear();
            toDie.Clear();
        }

        private void InitializeGrid()
        {
            //mainGrid.ShowGridLines = true;
            DefineRowAndColumns();

            cells = new Cell[numberOfRows, numberOfColumns];

            AddContentForEachRowAndColumn();
        }

        private void DefineRowAndColumns()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                mainGrid.RowDefinitions.Add(
                        new RowDefinition()
                        {
                            Height = new GridLength(1, GridUnitType.Star)
                        }
                    );
            }
            for (int j = 0; j < numberOfColumns; j++)
            {
                mainGrid.ColumnDefinitions.Add(
                        new ColumnDefinition()
                        {
                            Width = new GridLength(1, GridUnitType.Star)
                        }
                    );
            }
        }

        private void AddContentForEachRowAndColumn()
        {
            UIElementCollection gridChildren = mainGrid.Children;
            for (int i = 0, k = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++, k++)
                {
                    cells[i, j] = new Cell(mainGrid, i, j);
                    mainGrid.Children.Add(cells[i, j].Rectangle);
                    Grid.SetRow(cells[i, j].Rectangle, i);
                    Grid.SetColumn(cells[i, j].Rectangle, j);
                }
            }
            //koncowka inicjalizacji komorek
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    cells[i, j].FindNeighbours(cells, numberOfRows, numberOfColumns);
                }
            }
            //teraz kazda komorka zna swojego sasiada
        }
    }
}
