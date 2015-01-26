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
    abstract class Structure
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[][] cells;

        public Structure(int row, int column, int width, int height, Cell[][] cells)
        {
            this.Row = row;
            this.Column = column;
            this.Width = width;
            this.Height = height;
            this.cells = cells;
        }

        public abstract void Initialize();
        //public abstract void Evolve();
    }
}
