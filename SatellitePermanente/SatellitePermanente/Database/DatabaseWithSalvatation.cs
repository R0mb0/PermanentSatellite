﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SatellitePermanente.LogicAndMath
{
    interface DatabaseWithSalvatation: Database
    {
        public Boolean SalveDatabase();

        public Boolean LoadDatabase();
       
    }
}
