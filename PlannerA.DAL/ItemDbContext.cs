using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class ItemDbContext : ICrud<Item>
{

    public async Task<bool> InsertAsync(Item instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_items
                  VALUES (name = @name,
                          date_of_produce = @date_of_produce,
                          parameters = @parameters,
                          price = @price,
                          is_active = @is_active)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("date_of_produce", instance.date_of_produce);
        command.Parameters.AddWithValue("parameters", instance.parameters);
        command.Parameters.AddWithValue("price", instance.price);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Item instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_items
                  SET name = @name,
                      date_of_produce = @date_of_produce,
                      parameters = @parameters,
                      price = @price,
                      is_active = @is_active
                  WHERE name = @name
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("date_of_produce", instance.date_of_produce);
        command.Parameters.AddWithValue("parameters", instance.parameters);
        command.Parameters.AddWithValue("price", instance.price);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_items";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var items = new List<Item>();
        while (await reader.ReadAsync())
        {
            items.Add(new Item()
            {
                name = reader.GetString("name"),
                date_of_produce = reader.IsDBNull("date_of_produce")? null
                    : reader.GetDateTime("date_of_produce"),
                parameters = reader.IsDBNull("parameters")? null
                    : reader.GetString("parameters"),
                price = reader.IsDBNull("price")? null
                    : reader.GetDouble("price"),
                is_active = reader.GetBoolean("is_active"),
            });
        }
        await db.CloseAsync();
        return items;
    }
    public IEnumerable<Item> Find(Func<Item, bool> predicate)
    {
        throw new NotImplementedException();
    }
}