using Core.Services.EnumTableCreators.Interfaces;
using EnumsNET;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.EnumTableCreators
{
    public class EnumTableCreator : IEnumTableCreator
    {

        public void CreateAndFillTable<TEnum>(DbContext context)
        {
            var schema = GetSchema<TEnum>();

            CreateAndFillTable<TEnum>(context, schema);
        }

        public void FillTable<TEnum>(DbContext context)
        {
            var schema = GetSchema<TEnum>();

            FillTable<TEnum>(context, schema);
        }

        private static void CreateAndFillTable<TEnum>(DbContext context, string schema)
        {
            var tableName = GetTableName<TEnum>();

            CreateEnumTable(context, schema, tableName);

            foreach (var member in Enums.GetMembers(typeof(TEnum)))
            {
                FillTableWithEnumValues(context, schema, tableName, member);
            }
        }

        private static void FillTable<TEnum>(DbContext context, string schema)
        {
            var tableName = GetTableName<TEnum>();

            foreach (var member in Enums.GetMembers(typeof(TEnum)))
            {
                FillTableWithEnumValues(context, schema, tableName, member);
            }
        }

        private static string GetSchema<TEnum>()
        {
            return typeof(TEnum).Namespace!.Split('.')[0];
        }

        private static string GetTableName<TEnum>()
        {
            return typeof(TEnum).Name;
        }

        private static void CreateEnumTable(DbContext context, string schema, string tableName)
        {
            var sql = $@"
                CREATE TABLE [{schema}].[{tableName}] ( 
                    Id int NOT NULL,
                    Name nvarchar(100) NOT NULL,
                    Description nvarchar(255) NOT NULL,
                    CONSTRAINT[PK_{schema}.{tableName}] PRIMARY KEY CLUSTERED (Id ASC)
                ) ON[PRIMARY]
            ";

            context.Database.ExecuteSqlRaw(sql);
        }

        private static void FillTableWithEnumValues(DbContext context, string schema, string tableName, EnumMember enumMember)
        {
            var id = enumMember.Value;
            var name = enumMember.AsString(EnumFormat.Name);
            var description = enumMember.AsString(EnumFormat.Description, EnumFormat.Name);

            context.Database.ExecuteSqlRaw(
                $"INSERT INTO [{schema}].[{tableName}] (Id, Name, Description) VALUES (@id, @name, @description)",
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("description", description)
            );
        }
    }
}
