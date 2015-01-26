using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTheGame
{
    static class Statistics
    {
        public static uint StepCount { get; set; }

        public static void Initialize() 
        {
            StepCount = 0;
        }
    }
}
