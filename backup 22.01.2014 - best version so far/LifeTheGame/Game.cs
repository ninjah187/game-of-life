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
        private Canvas statsCanvas;
        private Label statsLabel1;
        private int numberOfRows;
        private int numberOfColumns;
        private Cell[][] cells;
        private List<Structure> structures;
        private List<Cell> aliveCells;
        private List<Cell> toLive;
        private List<Cell> toDie;

        private DispatcherTimer timer;

        public Game(Grid mainGrid, Canvas statsCanvas)
        {
            this.mainGrid = mainGrid;
            this.statsCanvas = statsCanvas;
            this.statsLabel1 = (Label)this.statsCanvas.Children[0];
            numberOfRows = (int)mainGrid.Height / 10;
            numberOfColumns = (int)mainGrid.Width / 10;
            InitializeGrid();
            structures = new List<Structure>();
            aliveCells = new List<Cell>();
            toLive = new List<Cell>();
            toDie = new List<Cell>();

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
            new Immortal(30, 30, cells);
            new Immortal(30, 90, cells);
            new Immortal(60, 60, cells);
            //new GliderGun(0, 0, cells, Directions.Right);
            //new Immortal(45, 60, cells);
            //new Exploder(45, 60, cells); new Exploder(45, 80, cells); new Exploder(45, 40, cells);
            //50, 60 55, 65 //55, 55
            /*Glider g2 = new Glider(35, 45, cells);
            new Glider(57, 47, cells);
            new Glider(52, 52, cells);
            new Glider(47, 57, cells);*/
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 50),//50 ms
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //określenie dla każdej komórki jej stanu w następnym kroku
            bool[,] lives = new bool[numberOfRows, numberOfColumns];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    lives[i, j] = cells[i][j].Evolve(cells, numberOfRows, numberOfColumns);
                }
            }
            //zmiana wyżej ustalonego stanu na aktualny
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
            }
            Statistics.StepCount++;
            statsLabel1.Content = "Liczba kroków: " + Statistics.StepCount.ToString();
        }

        private void InitializeGrid()
        {
            //mainGrid.ShowGridLines = true;
            DefineRowAndColumns();

            cells = new Cell[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                cells[i] = new Cell[numberOfColumns];
            }

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
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    cells[i][j] = new Cell(mainGrid, i, j);
                    mainGrid.Children.Add(cells[i][j].Rectangle);
                    Grid.SetRow(cells[i][j].Rectangle, i);
                    Grid.SetColumn(cells[i][j].Rectangle, j);
                }
            }
        }
    }
}
