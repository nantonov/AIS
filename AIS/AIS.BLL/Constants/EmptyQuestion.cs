using AIS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.BLL.Constants
{
    public static class EmptyQuestion
    {
        public static Question Empty = new() { Id = -1000};
    }
}
