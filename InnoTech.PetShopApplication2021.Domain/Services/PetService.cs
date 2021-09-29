using System;
using System.Collections.Generic;
using System.Linq;
using InnoTech.PetShopApplication2021.Domain.IRepositories;
using InnotTech.PetShopApplication2021.Core.Filtering;
using InnotTech.PetShopApplication2021.Core.IServices;
using InnotTech.PetShopApplication2021.Core.Models;

namespace InnoTech.PetShopApplication2021.Domain.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public List<Pet> GetAllPets(Filter filter)
        {
            if (filter == null || filter.Limit < 1 || filter.Limit > 100)
            {
                throw new ArgumentException("Filter Limit must be between 1 and 100");
            }

            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double)totalCount / filter.Limit);
            if (filter.Page < 1 || filter.Page > maxPageCount)
            { 
                throw new ArgumentException($"Filter Page must be between 1 and {maxPageCount}");
            }
            return _petRepository.ReadAll(filter);
        }

        public int TotalCount()
        {
            return _petRepository.TotalCount();
        }
    }
}