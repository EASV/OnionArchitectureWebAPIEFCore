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
        public List<Pet> ReadAll(Filter filter)
        {
            var selectQuery = _ctx.Pets.Select(pe => new Pet
            {
                Id = pe.Id,
                Name = pe.Name
            });
           
            if (filter.OrderDir.ToLower().Equals("asc"))
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderBy(p => p.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderBy(p => p.Id);
                        break;
                }
                
            }
            else
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderByDescending(p => p.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderByDescending(p => p.Id);
                        break;
                }
            }

            selectQuery = selectQuery.Where(p => p.Name.ToLower().StartsWith(filter.Search.ToLower()));
            var query = selectQuery
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return query.ToList();
        }

        public int TotalCount()
        {
            return _ctx.Pets.Count();
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
    }
}