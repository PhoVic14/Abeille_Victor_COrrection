using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin24_POO_VictorPholien
{
    internal class Collectrice : Abeille
    {
        public Collectrice()
        {
            Role = "Collectrice de Nectar";
            EnergieParQuart = 1.95d;
        }


        const double QTE_NECTAR_MAX_COLLECTE = 33.25d;

        /// <summary>
        /// Permet de collecter le nectar
        /// </summary>
        /// <param name="alea"></param>
        /// <param name="quantiteRecoltee"></param>
        /// <returns></returns>
        public double CollecteNectar()
        {
            Random alea = new Random();
            double quantiteRecoltee;

            quantiteRecoltee = alea.NextDouble() * QTE_NECTAR_MAX_COLLECTE;
            return quantiteRecoltee;
        }


        /// <summary>
        /// Permet de faire le job
        /// </summary>
        /// <param name="recolte"></param>
        /// <param name="alea"></param>
        /// <param name="quantiteRecoltee"></param>
        public override void FaitLeJob()
        {
            double recolte;
            recolte = CollecteNectar();
            if(recolte > 0)
            {
                Ruche.quantiteNectar = Ruche.quantiteNectar + recolte;
            }
            
        }


    }
}
