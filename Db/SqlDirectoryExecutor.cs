using FluentMigrator;

namespace Fluent_Migrator.Db
{
    public class SqlDirectoryExecutor
    {
        public static void ExecuteAllSqlInDirectory(Migration migration, string folderRelativePath, bool ignoreErrors = false)
        {
            var projectBasePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Scripts"));
            var targetDir = Path.Combine(projectBasePath, folderRelativePath);

            if (!Directory.Exists(targetDir))
                throw new DirectoryNotFoundException($"Directory not found: {targetDir}");

            var files = Directory.GetFiles(targetDir, "*.sql")
                                 .OrderBy(f => f);

            foreach (var file in files)
            {
                var sql = File.ReadAllText(file);
                try
                {
                    Console.WriteLine($"Executing {Path.GetFileName(file)}...");
                    migration.Execute.Sql(sql);
                }
                catch (Exception ex)
                {
                    if (!ignoreErrors)
                        throw new Exception($"Error executing {file}: {ex.Message}", ex);
                }
            }
        }
    }
}