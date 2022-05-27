using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Omnibus : Transporte
    {
        private string ramal;
        public string Ramal { get
            {
                return ramal;
            } }
        public Omnibus(int pasajeros, string ramal) : base(pasajeros)
        {
            this.ramal = ramal;
        }

        public override int Avanzar()
        {
            //Cuando km>40 el viaje finalizó y se reinicia, sino suma kms.
            if (km > 40)
            {
                km = 0;
            }
            return km += random.Next(7, 15);       
        }

        protected override int Calcular_pasajeros()
        {
            
            return pasajeros += random.Next(-10, 10); 
        }

        public override void Detenerse()
        {
            //Suben y bajan pasajeros del omnibus y sigue avanzando.
            this.Calcular_pasajeros();
            Avanzar();
        }

        public string Paradas()
        {
            if (km <= 10)
            {
                return $"El omnibus ramal {ramal} esta llegando a la 1° parada";
            }
            else if (km > 10 && km <= 20)
            {
                return $"El omnibus ramal {ramal} esta llegando a la 2° parada";
            }else if(km > 20 && km <= 30)
            {
                return $"El omnibus ramal {ramal} esta llegando a la 3° parada";
            }
            else if(km > 30 && km <= 40)
            {
                return $"El omnibus ramal {ramal} esta llegando al destino";
            }
            return "El omnibus aún no ha partido";
        }
    }
}

