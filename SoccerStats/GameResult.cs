﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{
    public class GameResult
    {
        public DateTime GameDate { get; set; }
        public string TeamName { get; private set; }
        public int MyProperty { get; private set; }
    }
}
