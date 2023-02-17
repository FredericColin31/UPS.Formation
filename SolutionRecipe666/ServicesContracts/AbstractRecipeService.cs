using DataContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    public abstract class AbstractRecipeService
    {
        public abstract List<Recipe> GetAll();

        protected List<Recipe> GetAllFromDB(String connectionString, String commandeText, System.Data.CommandType commandType)
        {
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = commandeText;
                cmd.CommandType = commandType;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["id"].ToString();
                    var title = reader["title"].ToString();

                    recipes.Add(new Recipe() { Id = Guid.Parse(id), Title = title });
                }

                return recipes;
            }
        }
    }
}
