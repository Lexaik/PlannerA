using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class OperationDbContext : ICrud<Operation>
{
    public async Task<bool> InsertAsync(Operation instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_operations 
                  VALUES 
                            (@name,
                          @type,
                          @duration,
                          @parameters,
                          @cost)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("type", instance.type);
        command.Parameters.AddWithValue("duration", instance.duration);
        command.Parameters.AddWithValue("parameters", instance.parameters);
        command.Parameters.AddWithValue("cost", instance.cost);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Operation instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_operations
                  SET name = @name,
                      type = @type,
                      duration = @duration,
                      parameters = @parameters,
                      cost = @cost
                  WHERE name = @name
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("type", instance.type);
        command.Parameters.AddWithValue("duration", instance.duration);
        command.Parameters.AddWithValue("parameters", instance.parameters);
        command.Parameters.AddWithValue("cost", instance.cost);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Operation>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_operations";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var operations = new List<Operation>();
        while (await reader.ReadAsync())
        {
            operations.Add(new Operation()
            {
                name = reader.GetString("name"),
                type = reader.GetString("type"),
                duration = reader.GetTimeSpan(Convert.ToInt32("duration")),
                parameters = reader.IsDBNull("parameters")? null
                    : reader.GetString("parameters"),
                cost = reader.GetDouble("cost"),
            });
        }
        await db.CloseAsync();
        return operations;
    }
    public IEnumerable<Operation> Find(Func<Operation, bool> predicate)
    {
        throw new NotImplementedException();
    }
}