using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class OrderDbContext : ICrud<Order>
{
    public async Task<bool> InsertAsync(Order instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_orders (name, client, date_start, date_end_plan, date_end, total_cost, description, is_active)
                  VALUES (@name, @client, @date_start, @date_end_plan, @date_end, @total_cost, @description, @is_active)
                  """;
        
        var parameters = new[]
        {
            new NpgsqlParameter("@name", instance.name),
            new NpgsqlParameter("@client", instance.client),
            new NpgsqlParameter("@date_start", instance.date_start),
            new NpgsqlParameter("@date_end_plan", instance.date_end_plan),
            new NpgsqlParameter("@date_end", instance.date_end ?? (object)DBNull.Value),
            new NpgsqlParameter("@total_cost", instance.total_cost),
            new NpgsqlParameter("@description", instance.description ?? (object)DBNull.Value),
            new NpgsqlParameter("@is_active", instance.is_active)
        };
        var result = await ExecuteNonQueryAsync(sql, parameters);
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Order instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_orders
                  SET name,
                      client,
                      date_start,
                      date_end_plan,
                      date_end,
                      total_cost,
                      description
                  WHERE order_id = @order_id
                  """;
        var command = new NpgsqlCommand(sql, db);
        //command.Parameters.AddWithValue("order_id", instance.order_id);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("client", instance.client);
        command.Parameters.AddWithValue("date_start", instance.date_start);
        command.Parameters.AddWithValue("date_end_plan", instance.date_end_plan);
        if (instance.date_end != null)
        command.Parameters.AddWithValue("date_end", instance.date_end);
        command.Parameters.AddWithValue("total_cost", instance.total_cost);
        command.Parameters.AddWithValue("description", instance.description);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = await command.ExecuteNonQueryAsync();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_orders";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var orders = new List<Order>();
        while (await reader.ReadAsync())
        {
            orders.Add(new Order()
            {
                order_id = reader.GetInt32("order_id"),
                name = reader.GetString("name"),
                client = reader.GetString("client"),
                date_start = reader.GetDateTime("date_start"),
                date_end_plan = reader.GetDateTime("date_end_plan"),
                date_end = reader.IsDBNull("date_end")? null
                    : reader.GetDateTime("date_end"),
                total_cost = reader.GetDouble("total_cost"),
                description = reader.GetString("description"),
            });
        }
        await db.CloseAsync();
        return orders;
    }
    public IEnumerable<Order> Find(Func<Order, bool> predicate)
    {
        throw new NotImplementedException();
    }
}