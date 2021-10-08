using System;
using System.Collections.Generic;

#nullable disable

namespace SeverRecipeAPI.Models
{
    public partial class MachineRecipe
    {
        public int RecipeId { get; set; }
        public string Time { get; set; }
        public string MachinePlc { get; set; }
        public string RecipeName { get; set; }
        public string Speed { get; set; }
        public string Temperature { get; set; }
    }
}
