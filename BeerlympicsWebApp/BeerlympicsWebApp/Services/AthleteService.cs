using BeerlympicsWebApp.Models;

namespace BeerlympicsWebApp.Services
{
    public class AthleteService
    {
        private readonly List<Athlete> _athletes;

        public AthleteService()
        {
            _athletes = new List<Athlete>
            {
                new Athlete
                {
                    FullName = "Philip Nagel",
                    NationalityCode = "DK",
                    Birthday = new DateTime(1999, 3, 19),
                    Height = 182,
                    City = "Odense"
                },
                new Athlete
                {
                    FullName = "Jakob Dahl",
                    NationalityCode = "DK",
                    Birthday = new DateTime(1999, 3, 19),
                    Height = 185,
                    City = "Odense"
                },
                new Athlete
                {
                    FullName = "Jakob Øzden",
                    NationalityCode = "FR",
                    Birthday = new DateTime(1999, 10, 6),
                    Height = 180,
                    City = "Odense"
                },
                new Athlete
                {
                    FullName = "Johnny Silverhand",
                    NationalityCode = "US",
                    Birthday = new DateTime(1988, 11, 16),
                    Height = 188,
                    City = "Night City"
                }
            };
        }

        public Athlete? GetAthleteBySlug(string slug)
        {
            return _athletes.FirstOrDefault(a => a.Slug == slug);
        }

        public List<Athlete> GetAllAthletes()
        {
            return _athletes;
        }
    }
}
