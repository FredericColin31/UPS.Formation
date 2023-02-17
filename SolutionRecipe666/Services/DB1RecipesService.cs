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
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection(Config.GetValueFrom("RecipesConnectionString")))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = "SELECT * FROM Recipes";
                cmd.CommandType = System.Data.CommandType.Text;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["id"].ToString();
                    var title = reader["title"].ToString();

                    recipes.Add(new Recipe() { Id=Guid.Parse(id), Title=title });
                }

                return recipes;
            }
        }
    }
}
