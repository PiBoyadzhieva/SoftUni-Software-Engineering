namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using System.Globalization;
    using System.Linq;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));

            var projectsDto = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));


            var sb = new StringBuilder();

            var projects = new List<Project>();

            foreach (var dto in projectsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectOpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime? projectDueDate = null;

                if (!string.IsNullOrWhiteSpace(dto.DueDate))
                {
                    projectDueDate = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                foreach (var taskDto in dto.Tasks)
                {
                    var isValidExecType = Enum.TryParse<ExecutionType>(taskDto.ExecutionType, out ExecutionType exType);
                    var isValidLabelType = Enum.TryParse<LabelType>(taskDto.ExecutionType, out LabelType labelType);

                    if (!IsValid(taskDto) || !isValidExecType || !isValidLabelType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    

                    if (taskDueDate > projectDueDate || taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = exType,
                        LabelType = labelType
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            var sb = new StringBuilder();

            foreach (var dto in employeesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                foreach (var currentTask in dto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => currentTask == t.Id);

                    if (task != null)
                    {
                        employee.EmployeesTasks.Add(new EmployeeTask
                        {
                            Task = task
                        });
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }


                employees.Add(employee);

                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));

            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}