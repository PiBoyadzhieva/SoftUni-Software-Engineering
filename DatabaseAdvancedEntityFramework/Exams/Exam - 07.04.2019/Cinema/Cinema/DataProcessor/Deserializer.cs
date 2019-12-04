namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ExportMovieDto[]>(jsonString);

            List<Movie> movies = new List<Movie>();

            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                bool isTitleExist = movies.Any(t => t.Title == movieDto.Title);
                bool isGenreValid = Enum.TryParse(movieDto.Genre, out Genre genre);

                if(isTitleExist == true || isGenreValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var duration = TimeSpan.ParseExact(movieDto.Duration, "c", CultureInfo.InvariantCulture);

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                bool isValidMovie = IsValid(movie);

                if(!isValidMovie)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(Object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}