using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin24_POO_VictorPholien
{
    internal abstract class Abeille
    {

        private string _role;
        private double _energieParQuart;


        public string Role
        {
            get 
            { 
                return _role; 
            }
            set 
            { 
                _role = value; 
            }
        }

        public double EnergieParQuart
        {
            get 
            {
                return _energieParQuart; 
            }
            set 
            { 
                _energieParQuart = value; 
            }
        }


        public bool EffectueLeProchainQuart()
        {
            bool ok;

            ok = false;
            
            if(Ruche.ConsommeMiel(_energieParQuart))
            {
                FaitLeJob();
                ok = true;
            }
            return ok;
        }


        public abstract void FaitLeJob();
        
    }
}
