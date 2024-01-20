using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using sib_api_v3_sdk.Model;

namespace JobCraft.Repositories.Implementation
{
    public class VacancyService : IVacancyService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public VacancyService(AppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public bool addVacancy(Vacancy model)
        {
            try
            {
                _dbContext.Vacancy.Add(model);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public VacancyList List()
        {
            var data = new VacancyList();
            var list = _dbContext.Vacancy.ToList();
            data.Vacancies = list.AsQueryable();
            return data;
        }

        public Vacancy getById(int id)
        {
            return _dbContext.Vacancy.Find(id);
        }
    }
}
