using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CE_Juin24_POO_VictorPholien
{
    internal class Reine : Abeille
    {
        public Reine()
        {
            Role = "Reine";
            EnergieParQuart = 2.15d;
        }


        public const double NB_OEUFS_PONDUS_PAR_QUART = 0.45d;

        private string _rapportEtatRuche;

		public string RapportEtatRuche
		{
			get
			{
				return _rapportEtatRuche; 
			}
			set 
			{
				_rapportEtatRuche = value; 
			}
		}

		/// <summary>
		/// Permet d'ajouter des abeilles a la ruche
		/// </summary>
		/// <param name="ok"></param>
		/// <returns></returns>
		public static bool AjouteAbeille(Abeille ouvriere)
		{
			bool ok;


            ok = false;
			if(Ruche.abeillesDisponibles >= 1)
			{
                ok = true;
				Ruche.abeillesDisponibles = Ruche.abeillesDisponibles - 1;
				Array.Resize(ref Ruche.ouvrieres, Ruche.ouvrieres.Length + 1);
				Ruche.ouvrieres[Ruche.ouvrieres.Length - 1] = ouvriere;
			}
			return ok;
		}

      
		/// <summary>
		/// Permet de donner une tache aux abeilles
		/// </summary>
		/// <param name="job"></param>
		/// <param name="message"></param>
        public void AffecteTache(string job, out string message)
		{
			message = "";
			bool ok = false;

			if(job == "Collectrice de Nectar")
			{
				ok = AjouteAbeille(new Collectrice());
				message = "Une collectrice ajoutée";
			}

			else if(job == "Gardinne des oeufs")
			{
                ok = AjouteAbeille(new Couveuse());
                message = "Une couveuse ajoutée";
            }

			else if(job == "Productrice de Miel")
			{
                ok = AjouteAbeille(new Productrice());
                message = "Une productrice ajoutée";
            }

			if (!ok)
			{
				message = "Plus d'abeille disponible";
			}
			
		}

		/// <summary>
		/// permet de ponde
		/// </summary>

		public void Pond()
		{
			Ruche.nombreOeufs = Ruche.nombreOeufs + NB_OEUFS_PONDUS_PAR_QUART;
        }


		/// <summary>
		/// Fait le job
		/// </summary>
		/// <param name="i"></param>
		public override void FaitLeJob()
		{
		

            Ruche.alerteManqueMiel = "";
            Ruche.alerteManqueNectar = "";
			Pond();

			for(int i = 0;i <= Ruche.ouvrieres.Length-1;i++) 
			{
				if (Ruche.ouvrieres[i].EffectueLeProchainQuart())
				{
					Ruche.alerteManqueMiel = "";
				}
			}

			if((!Ruche.ConsommeMiel(Ruche.MIEL_CONSOMME_PAR_NON_TRAVAILLEUSES * (Ruche.abeillesDisponibles))))
			{
				Ruche.alerteManqueMiel = "Pas assez de miel pour nourrir tout le monde, affecter des productrices !";
				RapportEtatRuche = Ruche.EcritRapportQuart();
			}

        }


	}
}