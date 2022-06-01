using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public class PersonalException: Exception
    {
        public override string Message => "Ay! caramba!"+base.Message;

        //Creo una clase hija que hereda el constructor de Exception y le envio el mensaje personalizado
        public PersonalException(string mensaje): base(mensaje)
        {
            
        }
    }
}
