using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Factory
    {
        static Factory()
        {
            // Lire les paramètres du fichier de configuration

            // créer l'instance de la bonne classe concrète
        }
        public static AbtractRecipeService? Instance { get; set; }
    }
}
