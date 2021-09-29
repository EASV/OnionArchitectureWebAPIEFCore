using System.Collections.Generic;
using InnotTech.PetShopApplication2021.Core.Filtering;
using InnotTech.PetShopApplication2021.Core.Models;

namespace InnotTech.PetShopApplication2021.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets(Filter filter);
        int TotalCount();
    }
}