using Microsoft.Extensions.Configuration;
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
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            var config = configuration.Build();
            var afn = config.GetSection("AssemblyFileName").Value;
            var cn = config.GetSection("ClassName").Value;

            // créer l'instance de la bonne classe concrète
            Instance = (Activator.CreateInstance(afn, cn).Unwrap()) as AbtractRecipeService;
        }

        public static AbtractRecipeService? Instance { get; set; }
    }
}
