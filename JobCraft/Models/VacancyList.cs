namespace JobCraft.Models
{
    public class VacancyList
    {
        public IQueryable<Vacancy> Vacancies { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasMoreData { get; set; }

    }
}
