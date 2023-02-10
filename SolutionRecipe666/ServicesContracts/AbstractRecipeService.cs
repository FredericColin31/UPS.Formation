using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    public abstract class AbstractRecipeService
    {
        public abstract List<Recipe> GetAll();
    }
}
