using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    interface IStructure
    {
        int Row { get; set; }
        int Column { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        void nic();
    }
}
