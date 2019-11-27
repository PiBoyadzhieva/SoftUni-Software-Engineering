using MiniOrmApp.Data;
using System.Linq;

namespace MiniOrmApp
{
    public class StartUp
    {
        public static void Main()
        {
            const string connectionString = @"Server=.\SQLEXPRESS01;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            var employees = context.Employees.ToList();

            ;
        }
    }
}
