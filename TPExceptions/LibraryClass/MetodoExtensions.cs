using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public static class MetodoExtensions
    {
        public static int Dividir(this int numA,int numB)
        {
            int resultado;
            try
            {
                resultado = numA / numB;
            }
            catch (DivideByZeroException e)
            {

                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
            return resultado;
        }
    }
}
