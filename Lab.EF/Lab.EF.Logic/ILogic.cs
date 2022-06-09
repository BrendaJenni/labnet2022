using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    internal interface ILogic<T> where T : class
    {
        List<T> GetAll();
    }
}
