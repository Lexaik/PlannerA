using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class ClientDbContext : ICrud<Client>
{
    public async Task<bool> InsertAsync(Client instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_clients
                  VALUES (name = @name,
                  address = @address,
                  phone = @phone,
                  email = @email,
                  worker_id = @worker_id,
                  is_active = @is_active)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("address", instance.address);
        command.Parameters.AddWithValue("phone", instance.phone);
        command.Parameters.AddWithValue("email", instance.email);
        command.Parameters.AddWithValue("worker_id", instance.worker_id);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Client instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_clients
                  SET name = @name,
                  address = @address,
                  phone = @phone,
                  email = @email,
                  worker_id = @worker_id,
                  is_active = @is_active 
                  WHERE name = @_name
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("address", instance.address);
        command.Parameters.AddWithValue("phone", instance.phone);
        command.Parameters.AddWithValue("email", instance.email);
        command.Parameters.AddWithValue("worker_id", instance.worker_id);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_clients";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var clients = new List<Client>();
        while (await reader.ReadAsync())
        {
            clients.Add(new Client()
            {
                name = reader.GetString("name"),
                address = await reader.IsDBNullAsync("address")? null
                    : reader.GetString("address"),
                phone = await reader.IsDBNullAsync("phone")? null
                    : reader.GetString("phone"),
                email = await reader.IsDBNullAsync("email")? null
                    :reader.GetString("email"),
                worker_id = reader.GetInt16("worker_id"),
                is_active = reader.GetBoolean("is_active"),
            });
        }
        await db.CloseAsync();
        return clients;
    }
    public IEnumerable<Client> Find(Func<Client, bool> predicate)
    {
        throw new NotImplementedException();
    }
}