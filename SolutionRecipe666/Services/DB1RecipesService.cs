using DataContracts;
using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DB1RecipesService : AbstractRecipeService
    {
        public override List<Recipe> GetAll()
        {
            return GetAllFromDB(Config.GetValueFrom("RecipesConnectionString"), "SELECT * FROM Recipes", System.Data.CommandType.Text);
        }
    }
}
