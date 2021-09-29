using System.Collections.Generic;
using InnotTech.PetShopApplication2021.Core.Filtering;
using InnotTech.PetShopApplication2021.Core.Models;

namespace InnoTech.PetShopApplication2021.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> ReadAll(Filter filter);
        int TotalCount();
    }
}