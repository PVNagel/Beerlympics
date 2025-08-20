using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BeerlympicsWebApp.Models
{
    public class Athlete
    {
        public required string FullName { get; set; }
        public required string NationalityCode { get; set; } // ISO 3166-1 alpha-2 code, e.g., "DK", "US", "FR"
        public required DateTime Birthday { get; set; }
        public int Height { get; set; } // in centimeters
        public string City { get; set; } = string.Empty;

        public int Age => CalculateAge(Birthday);

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            var birthdayThisYear = birthDate.AddYears(age);

            // If this year's birthday hasn’t happened yet, subtract one from the age
            if (today < birthdayThisYear)
            {
                age--;
            }

            return age;
        }

        // Get full country name from ISO code
        public string NationalityName => new RegionInfo(NationalityCode).DisplayName;

        // Dynamically generate the image URL based on Name
        public string ImageUrl => $"/images/athletes/{ToSafeFileName(FullName)}.png";

        // Helper method to generate safe filenames
        private static string ToSafeFileName(string fullName)
        {
            // Normalize the string to decompose accented characters (e.g., Ø -> O)
            var normalizedName = fullName.Normalize(NormalizationForm.FormD);

            // Remove all diacritic marks
            var stringWithoutDiacritics = new StringBuilder();
            foreach (var character in normalizedName)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                    stringWithoutDiacritics.Append(character);
            }

            var lowerCasedName = stringWithoutDiacritics.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();

            // Replace spaces with underscores and remove any remaining non-alphanumeric characters
            var safeFileName = Regex.Replace(lowerCasedName, @"[^a-z0-9_]", "_");

            return safeFileName;
        }
    }
}
