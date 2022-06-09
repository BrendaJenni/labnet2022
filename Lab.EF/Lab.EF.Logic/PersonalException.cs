﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class PersonalException : Exception
    {
        public override string Message => "El ID ingresado no existe " + base.Message;
        public PersonalException()
        {

        }
    }
}
