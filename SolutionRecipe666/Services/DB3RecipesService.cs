using DataContracts;
using Services.DataAccessLayer;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DB3RecipesService : AbstractRecipeService
    {
        public override List<DataContracts.Recipe> GetAll()
        {
            using (var context = new BRecipesContext())
            {
                return context.Recipes.Select(@r => new DataContracts.Recipe { Id = @r.Id, Title=@r.Title }).ToList();
            }
        }
    }
}
