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
            if (filter.Count <= 0 || filter.Count > 500)
            {
               throw new ArgumentException("You need to put in a filter count between 1 and 500");
            }

            var totalCount =  _petRepository.Count();
            if (filter.Page < 1 || filter.Count * (filter.Page - 1) > totalCount)
            {
                throw new ArgumentException($"You need to put in a filter page between 1 and max page size, max page size allowed now: {(totalCount / filter.Count) + 1}");
            }
            
            return _petRepository.ReadAllPets(filter);
        }

        public int GetTotalPetCount()
        {
            return _petRepository.Count();
        }
    }
}