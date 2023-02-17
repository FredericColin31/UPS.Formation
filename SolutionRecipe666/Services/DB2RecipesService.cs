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
    public class DB2RecipesService : AbstractRecipeService
    {
        public override List<Recipe> GetAll()
        {
            return GetAllFromDB(Config.GetValueFrom("RecipesConnectionString"), "sSelectRecipes", System.Data.CommandType.StoredProcedure);
        }
    }
}
