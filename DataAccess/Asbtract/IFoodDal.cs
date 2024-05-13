﻿using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Asbtract
{
    public interface IFoodDal : IBaseRepository<Food> 
    {
        List<Food> GetFoodWithFoodCategories();
    }

}
