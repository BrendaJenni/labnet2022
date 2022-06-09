using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, ILogic<Customers>
    {
        public CustomersLogic()
        {         
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
