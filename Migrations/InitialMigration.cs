using Fluent_Migrator.Db;
using FluentMigrator;

namespace Fluent_Migrator.Migrations
{
    [Migration(01)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            SqlDirectoryExecutor.ExecuteAllSqlInDirectory(this, "Tables");
            SqlDirectoryExecutor.ExecuteAllSqlInDirectory(this, "UDTT");
            SqlDirectoryExecutor.ExecuteAllSqlInDirectory(this, "SP");
            SqlDirectoryExecutor.ExecuteAllSqlInDirectory(this, "Functions");
            SqlDirectoryExecutor.ExecuteAllSqlInDirectory(this, "Views");
        }
        public override void Down()
        {
            //
        }
    }
}