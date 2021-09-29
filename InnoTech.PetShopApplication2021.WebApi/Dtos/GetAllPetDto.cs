using System.Collections.Generic;

namespace InnoTech.PetShopApplication2021.WebApi.Dtos
{
    public class GetAllPetDto
    {
        public List<GetPetDto> List { get; set; }
        public int TotalCount { get; set; }
    }
}