using DataContracts;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services
{
    public class Xml1RecipesService : AbstractRecipeService
    {
        public override List<Recipe> GetAll()
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load("recipes.xml");

            var recipes = new List<Recipe>();

            var nodes = xmlDoc.SelectNodes("/recipes/recipe");

            foreach(XmlNode node in nodes)
            {
                recipes.Add(new Recipe() { Title = node?.Attributes["title"].Value, Id = Guid.Parse(node?.Attributes["id"].Value) });
            }


            return recipes;
        }
    }
}
