using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin24_POO_VictorPholien
{
        static class Ruche
        {
            // constantes globales
            public const double TAUX_CONVERSION_NECTAR_EN_MIEL = 0.19d;
            public const double NIVEAU_ALERTE_BAS = 10d;
            public const double MIEL_CONSOMME_PAR_NON_TRAVAILLEUSES = 0.5d;
            public const int NOMBRE_OEUFS_POUR_ECLOSIONS = 5;

            // unités de Nectar présentes dans la ruche
            public static double quantiteNectar = 100d;

            // unités de miel disponible
            public static double quantiteMiel = 50d;

            // nombre d'oeufs
            public static double nombreOeufs = 25;

            // ouvrières
            public static Abeille[] ouvrieres = new Abeille[0];

            // abeilles non encore affectées
            public static int abeillesDisponibles = 15;

            // messages d'avertissement
            public static string alerteManqueMiel = "";
            public static string alerteManqueNectar = "";


            // fonction booléenne pour piocher dans la réserve de miel
            public static bool ConsommeMiel(double quantiteMielConso)
            {
                bool peutSeNourrir = false;
                if (quantiteMiel > quantiteMielConso)
                {
                    quantiteMiel -= quantiteMielConso;
                    peutSeNourrir = true;
                }
                return peutSeNourrir;
            }

            /// <summary>
            /// Permet de voir le nombre d'ouvrier selon le job
            /// </summary>
            /// <param name="typeJob">Le type de job ouvrier garde etc</param>
            /// <param name="compteAbeille">Le nombre d'abeille</param>
            /// <returns></returns>
            public static int NbOuverieresSelonJob(string typeJob)
            {
                int compteAbeille = 0;
                
                for (int i = 0; i < ouvrieres.Length; i++)
                {
                    Abeille abeille = ouvrieres[i];
                    if(abeille.Role == typeJob)
                    {
                        compteAbeille = compteAbeille +1;
                    }
                }
                return compteAbeille;

                
            }

            /// <summary>
            /// Permet d'ecrire le rapport apres tout les quarts
            /// </summary>
            /// <param name="rapport"></param>
            /// <returns></returns>

            public static string EcritRapportQuart()
            {
                string rapport;
                rapport = "";
                alerteManqueNectar = "";

                if(quantiteNectar < NIVEAU_ALERTE_BAS)
                {
                    alerteManqueNectar = "Niveau de Nectar au plus bas ! envoyez des collectrices !";
                }

                rapport = $"Rapport de Quart : \n {quantiteMiel:0.0} unités de Miel\n {quantiteNectar:0.0} unités de Nectar \n{alerteManqueNectar} \n{alerteManqueMiel}";

                rapport += $"\nNombre d'oeufs : {nombreOeufs:0.00} \n{NbOuverieresSelonJob("Collectrice de nectar")} Collectrice de Nectar \n{NbOuverieresSelonJob("Productrice de Miel")} Productrice de miel \n{NbOuverieresSelonJob("Gardienne des oeufs")} Gardienne des oeufs \nNombre d'abeilles disponibles {abeillesDisponibles}";
            return rapport;
            }
        }
    }

