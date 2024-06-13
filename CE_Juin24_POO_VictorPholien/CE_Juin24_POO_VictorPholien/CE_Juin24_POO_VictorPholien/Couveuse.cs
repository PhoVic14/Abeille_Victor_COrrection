using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin24_POO_VictorPholien
{
    internal class Couveuse : Abeille
    {
        public Couveuse()
        {
            Role = "Gardienne des oeufs";
            EnergieParQuart = 1.35d;
        }



        /// <summary>
        /// Faire eclore les oeufs quand ils sont 5
        /// </summary>
        public void Eclosions()
        {
           if(Ruche.nombreOeufs > 5)
            {
                Ruche.abeillesDisponibles = Ruche.abeillesDisponibles + 5;
                Ruche.nombreOeufs = Ruche.nombreOeufs - 5;
            }
        }

        /// <summary>
        /// Faire le job 
        /// </summary>
        public override void FaitLeJob()
        {
            Eclosions();
        }
    }
}
