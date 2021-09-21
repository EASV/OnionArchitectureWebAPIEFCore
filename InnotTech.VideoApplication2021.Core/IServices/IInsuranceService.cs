using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnotTech.VideoApplication2021.Core.IServices
{
    public interface IInsuranceService
    {
        Insurance GetById(int id);
        Insurance Create(Insurance insurance);
        List<Insurance> GetAll();
        Insurance Delete(int id);
        Insurance Update(Insurance insurance);
    }
}