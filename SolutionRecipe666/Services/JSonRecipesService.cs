using DataContracts;
using Newtonsoft.Json;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JSonRecipesService : AbstractRecipeService
    {
        public override List<Recipe> GetAll()
        {
            var serializedString = File.ReadAllText("recipes.json");
            return JsonConvert.DeserializeObject<List<Recipe>>(serializedString);   
        }
    }
}
