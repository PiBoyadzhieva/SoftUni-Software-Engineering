namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
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
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            List<Movie> movies = new List<Movie>();

            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                bool isTitleExist = movies.Any(t => t.Title == movieDto.Title);
                bool isGenreValid = Enum.TryParse(movieDto.Genre, out Genre genre);

                if(isTitleExist == true || isGenreValid == false || !IsValid(movieDto))
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

                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            List<Hall> halls = new List<Hall>();

            StringBuilder sb = new StringBuilder();

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto) || hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,
                };

                for (int seat = 1; seat <= hallDto.Seats; seat++)
                {
                    hall.Seats.Add(new Seat 
                    { 
                        Hall = hall 
                    });
                }

                halls.Add(hall);

                var hallProjectionType = string.Empty;

                if(hall.Is3D == true && hall.Is4Dx == true)
                {
                    hallProjectionType = "4Dx/3D";
                }

                else if (hall.Is4Dx == true)
                {
                    hallProjectionType = "4Dx";
                }

                else if (hall.Is3D == true)
                {
                    hallProjectionType = "3D";
                }

                else
                {
                    hallProjectionType = "Normal";
                }

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, hallProjectionType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            using var reader = new StringReader(xmlString);

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(reader);

            var sb = new StringBuilder();

            var projections = new List<Projection>();

            foreach (var projectionDto in projectionsDto)
            {
                var movie = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId);
                var hall = context.Halls.FirstOrDefault(m => m.Id == projectionDto.HallId);

                if (!IsValid(projectionDto) || movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, @"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                //``var projectionTitle = context.Movies.Find(projectionDto.MovieId).Title;
                var dateTime = projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, dateTime));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(xmlString);

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

            var sb = new StringBuilder();

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto) || !customerDto.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                    Tickets = customerDto.Tickets
                        .Select(t => new Ticket
                        {
                            ProjectionId = t.ProjectionId,
                            Price = t.Price
                        })
                        .ToArray()
                };

                customers.Add(customer);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, 
                    customer.FirstName, 
                    customer.LastName, 
                    customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
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