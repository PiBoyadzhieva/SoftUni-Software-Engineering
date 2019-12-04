namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var departments = new List<Department>();

            var sb = new StringBuilder();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto) || departmentDto.Cells.Any(c => !IsValid(c)) /*!departmentDto.Cells.All(IsValid)*/)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    })
                    .ToList()
                };

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                bool isValidMail = prisonerDto.Mails.All(IsValid);


                if (!IsValid(prisonerDto) || !isValidMail)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                DateTime? releaseDate = null;

                if (prisonerDto.ReleaseDate != null)
                {
                    releaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = prisonerDto.Mails
                        .Select(m => new Mail
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        })
                        .ToList()
                };

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            using var reader = new StringReader(xmlString);

            var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(reader);

            var sb = new StringBuilder();

            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                var isValidPosition = Enum.TryParse<Position>(officerDto.Position, out Position position);
                var isValidWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officerDto) || !isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners
                        .Select(p => new OfficerPrisoner
                        {
                            PrisonerId = p.Id
                        })
                        .ToArray()
                };

                //var officer = new Officer
                //{
                //    FullName = officerDto.Name,
                //    Salary = officerDto.Money,
                //    Position = position,
                //    Weapon = weapon,
                //    DepartmentId = officerDto.DepartmentId,
                //};

                //foreach (var prisoner in officerDto.Prisoners)
                //{
                //    officer.OfficerPrisoners.Add(new OfficerPrisoner
                //    {
                //        PrisonerId = prisoner.Id
                //    });
                //}

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }

    }
}