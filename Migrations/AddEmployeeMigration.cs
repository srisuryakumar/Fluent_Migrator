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
            Execute.Sql(File.ReadAllText("Scripts/SP/InsertEmployee.sql"));
        }
        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS Employees");
            Execute.Sql("DROP PROCEDURE IF EXISTS GetAllEmployees");
            Execute.Sql("DROP PROCEDURE IF EXISTS InsertEmployee");
        }
    }
}