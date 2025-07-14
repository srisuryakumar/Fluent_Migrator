using Fluent_Migrator.Db;
using FluentMigrator;

namespace Fluent_Migrator.Migrations
{
    [Migration(02)]
    public class AddEmployeeMigration : Migration
    {
        public override void Up()
        {
            Execute.Sql(File.ReadAllText("Scripts/Tables/Employees.sql"));
            Execute.Sql(File.ReadAllText("Scripts/SP/GetAllEmployees.sql"));
            Execute.Sql(File.ReadAllText("Scripts/SP/InsertEmployees.sql"));
        }
        public override void Down()
        {
            //
        }
    }
}