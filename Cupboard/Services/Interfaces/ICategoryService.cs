﻿using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{

    //OBS att service
    //Inte kanske kräver samma parametrar som repot!
    //OCH
    //vissa av dem behöver DTOs!
    public interface ICategoryService
    {
        Category GetCategory(int id);

        ICollection<Category> GetCategories();
    }
}