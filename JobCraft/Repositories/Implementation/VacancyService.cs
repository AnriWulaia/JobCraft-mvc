using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

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
    }
}
