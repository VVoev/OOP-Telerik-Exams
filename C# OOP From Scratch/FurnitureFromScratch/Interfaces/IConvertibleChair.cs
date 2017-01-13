﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Interfaces
{
    public interface IConvertibleChair : IChair
    {
       bool IsConverted { get; }
       void Convert();
    }
}
