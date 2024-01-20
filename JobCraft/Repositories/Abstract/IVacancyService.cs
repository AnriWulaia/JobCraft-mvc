using JobCraft.Models;

namespace JobCraft.Repositories.Abstract
{
    public interface IVacancyService
    {
        bool addVacancy(Vacancy model);
        VacancyList List();
        Vacancy getById(int id);

    }
}
