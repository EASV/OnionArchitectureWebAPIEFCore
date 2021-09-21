using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.EFCore.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.EFCore.Repositories
{
    public class InsuranceRepository: IInsuranceRepository
    {
        private readonly VideoApplicationDbContext _ctx;

        public InsuranceRepository(VideoApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance GetById(int id)
        {
            return _ctx.Insurances
                .Select(ie => new Insurance
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(insurance => insurance.Id == id);
        }

        public Insurance Create(Insurance insurance)
        {
            var entity = _ctx.Add(new InsuranceEntity
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public List<Insurance> ReadAll()
        {
            return _ctx.Insurances
                .Select(insurance => new Insurance
                {
                    Id = insurance.Id,
                    Name = insurance.Name,
                    Price = insurance.Price
                })
                .ToList();
        }

        public Insurance Delete(int id)
        {
            var entity = _ctx.Remove(new InsuranceEntity{Id = id}).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id
            };
        }

        public Insurance Update(Insurance insurance)
        {
            var insuranceEntity = new InsuranceEntity
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            var entity = _ctx.Update(insuranceEntity).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}