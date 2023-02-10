using DataContracts;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class Xml2RecipesService : AbtractRecipeService
    {
        public override List<Recipe> GetAll()
        {
            var xdoc = XDocument.Load("recipes.xml");

            //return xdoc.Descendants("recipe").Select(@node => new Recipe { Id = Guid.Parse(@node?.Attribute("id").Value), Title = @node?.Attribute("title").Value }).ToList();

            return (from XElement node in xdoc.Descendants("recipe") 
                    select new Recipe { Id = Guid.Parse(@node?.Attribute("id").Value), Title = @node?.Attribute("title").Value }).ToList();



        }
    }
}
