﻿using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface IRecipeRepo
    {
        void CreateRecipe(Recipe recipe);

        Recipe ReadRecipe(string recipeId);

        void UpdateRecipe(Recipe recipe);

        //might need user id here too tbh
        //but preferable, this will be solved in the service layer imo
        //because this is ONLY a commandeering layer
        void DeleteRecipe(string recipeId);
    }
}
