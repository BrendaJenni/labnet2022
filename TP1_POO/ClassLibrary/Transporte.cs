using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Transporte
    {
        public int pasajeros { get; set; }
        public int km;
        protected Random random = new Random(Guid.NewGuid().GetHashCode());
        public Transporte (int pasajeros)
        {
            this.pasajeros = pasajeros;
            this.km = 0;
        }
        public abstract int Avanzar();

        public abstract void Detenerse();
        protected abstract int Calcular_pasajeros();
        
    }
}
