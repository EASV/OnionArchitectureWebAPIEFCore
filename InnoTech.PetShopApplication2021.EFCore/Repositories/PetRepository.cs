using System.Collections.Generic;
using System.Linq;
using InnoTech.PetShopApplication2021.Domain.IRepositories;
using InnoTech.PetShopApplication2021.EFCore.Entities;
using InnotTech.PetShopApplication2021.Core.Filtering;
using InnotTech.PetShopApplication2021.Core.Models;

namespace InnoTech.PetShopApplication2021.EFCore.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopApplicationDbContext _ctx;

        public PetRepository(PetShopApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Pet> ReadAllPets(Filter filter)
        {
            var selectQuery = _ctx.Pets
                .Select(pe => new Pet
                {
                    Id = pe.Id,
                    Name = pe.Name
                });
            var paging = selectQuery.Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count); //How many to get back in the Query
            
            if (string.IsNullOrEmpty(filter.SortOrder) || filter.SortOrder.Equals("asc"))
            {
                switch (filter.SortBy)
                {
                    case "id": 
                        paging = paging.OrderBy(p => p.Id);
                        break;
                    case "name":
                        paging = paging.OrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                switch (filter.SortBy)
                {
                    case "id": 
                        paging = paging.OrderByDescending(p => p.Id);
                        break;
                    case "name":
                        paging = paging.OrderByDescending(p => p.Name);
                        break;
                }
            }
            return paging.ToList();
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
    }
}