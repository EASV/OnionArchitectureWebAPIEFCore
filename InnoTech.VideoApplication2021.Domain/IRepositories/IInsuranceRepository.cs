using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        Insurance Create(Insurance insurance);
        List<Insurance> ReadAll();
        Insurance Delete(int id);
        Insurance Update(Insurance insurance);
    }
}