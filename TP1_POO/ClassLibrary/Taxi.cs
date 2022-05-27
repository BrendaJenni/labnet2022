using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Taxi : Transporte
    {
        private string codigo;
        private int tarifa = 200;
        public string Codigo
        {
            get
            {
                return codigo;
            }
        }
        public int Tarifa
        {
            get
            {
                return tarifa;
            }
        }
        public Taxi(int pasajeros, string codigo) : base(pasajeros)
        {
            this.codigo = codigo;
        }

        public override int Avanzar()
        {
            //El taxi avanza y calcular el valor de la tarifa según lo recorrido.
            km += random.Next(1, 15);
            return tarifa += (km * 200);
        }

        protected override int Calcular_pasajeros()
        {
            if (pasajeros == 0)
            {
                //Cuando no hay pasajeros, agrega de nuevo.
                return pasajeros = random.Next(1, 5);
            }
            return -1;
        }

        public override void Detenerse()
        {
            //Los pasajeros se bajan, pagan la tarifa y se reinician la variables, luego ingresan mas pasajeros.
            pasajeros = 0;
            tarifa = 200;
            km = 0;
            this.Calcular_pasajeros();
        }
    }
}
