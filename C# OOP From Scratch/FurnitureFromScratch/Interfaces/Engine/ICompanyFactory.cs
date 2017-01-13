﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Interfaces.Engine
{
    public interface ICompanyFactory
    {
        ICompany CreateCompany(string name, string registrationNumber);
    }
}
