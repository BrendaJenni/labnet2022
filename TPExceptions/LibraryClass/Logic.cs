using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public class Logic
    {
        public Logic()
        {

        }
        public void ThrowException()
        {
            throw new StackOverflowException();
        }
        public void ThrowPersonalException()
        {
            throw new PersonalException("Una Excepcion!! AAAG");
        }
    }
}
