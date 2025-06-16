using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class DepartmentDbContext : ICrud<Department>
{
    public async Task<bool> InsertAsync(Department instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_departments
                  VALUES (name = @name,
                  person_id = @person_id,
                  description = @description,
                  is_active = @is_active)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("person_id", instance.person_id);
        command.Parameters.AddWithValue("description", instance.description);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Department instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_departments
                  SET name = @name,
                  person_id = @person_id,
                  description = @description,
                  is_active = @is_active
                  WHERE name = @name
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("person_id", instance.person_id);
        command.Parameters.AddWithValue("description", instance.description);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_departments";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var departments = new List<Department>();
        while (await reader.ReadAsync())
        {
            departments.Add(new Department()
            {
                name = reader.GetString("name"),
                person_id = reader.GetInt16("person_id"),
                description = reader.IsDBNull("description")? null
                    : reader.GetString("description"),
                is_active = reader.GetBoolean("is_active"),
            });
        }
        await db.CloseAsync();
        return departments;
    }
    public IEnumerable<Department> Find(Func<Department, bool> predicate)
    {
        throw new NotImplementedException();
    }
}