using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin24_POO_VictorPholien
{
    internal class Productrice : Abeille
    {
        public Productrice()
        {
            Role = "Productrice de Miel";
            EnergieParQuart = 1.7d;
        }


        const double QTE_MAX_MIEL_PRODUIT_PAR_QUART = 33.15d;
        const double TAUX_CONVERSION_NECTAR_EN_MIEL = 0.19d;

        /// <summary>
        /// Permet de transformer le nectar en miel
        /// </summary>
        /// <param name="quatiteNectarTransforme"></param>
        /// <param name="alea"></param>
        /// <returns></returns>
        public double TransformeNectarEnMiel()
        {
            double quatiteNectarTransforme;
            Random alea = new Random();

            quatiteNectarTransforme = alea.NextDouble() * Ruche.quantiteNectar;

            if (quatiteNectarTransforme > (QTE_MAX_MIEL_PRODUIT_PAR_QUART / TAUX_CONVERSION_NECTAR_EN_MIEL))
            {
                quatiteNectarTransforme = QTE_MAX_MIEL_PRODUIT_PAR_QUART / TAUX_CONVERSION_NECTAR_EN_MIEL;
            }
            return quatiteNectarTransforme;
        }


        /// <summary>
        /// Faire le job
        /// </summary>
        /// <param name="qteNectarTransforme"></param>
        public override void FaitLeJob()
        {
            double qteNectarTransforme;

            qteNectarTransforme = TransformeNectarEnMiel();

            if(qteNectarTransforme > 0)
            {
                Ruche.quantiteNectar = Ruche.quantiteNectar - qteNectarTransforme;
                Ruche.quantiteMiel += qteNectarTransforme * TAUX_CONVERSION_NECTAR_EN_MIEL;
            }
            else
            {
                Ruche.alerteManqueNectar = "Plus de Nectar ! envoyez des collectrices !";
            }
        }
    }
}
