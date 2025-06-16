using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class ProcessDbContext : ICrud<Process>
{

    public async Task<bool> InsertAsync(Process instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_processes
                  VALUES (process_id = @process_id,
                          order_id = @order_id,
                          item = @item,
                          quantity = @quantity,
                          operation = @operation,
                          oper_duration = @oper_duration,
                          type = @type,
                          date_start = @date_start,
                          date_end = @date_end)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("process_id", instance.process_id);
        command.Parameters.AddWithValue("order_id", instance.order_id);
        command.Parameters.AddWithValue("item", instance.item);
        command.Parameters.AddWithValue("quantity", instance.quantity);
        command.Parameters.AddWithValue("operation", instance.operation);
        command.Parameters.AddWithValue("oper_duration", instance.oper_duration);
        command.Parameters.AddWithValue("type", instance.type);
        command.Parameters.AddWithValue("date_start", instance.date_start);
        command.Parameters.AddWithValue("date_end", instance.date_end);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Process instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_processes
                  SET process_id = @process_id,
                      order_id = @order_id,
                      item = @item,
                      quantity = @quantity,
                      operation = @operation,
                      oper_duration = @oper_duration,
                      type = @type,
                      date_start = @date_start,
                      date_end = @date_end
                  WHERE process_id = @process_id
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("process_id", instance.process_id);
        command.Parameters.AddWithValue("order_id", instance.order_id);
        command.Parameters.AddWithValue("item", instance.item);
        command.Parameters.AddWithValue("quantity", instance.quantity);
        command.Parameters.AddWithValue("operation", instance.operation);
        command.Parameters.AddWithValue("operDur", instance.oper_duration);
        command.Parameters.AddWithValue("type", instance.type);
        command.Parameters.AddWithValue("date_start", instance.date_start);
        command.Parameters.AddWithValue("date_end", instance.date_end);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Process>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_processes";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var processes = new List<Process>();
        while (await reader.ReadAsync())
        {
            processes.Add(new Process()
            {
                process_id = reader.GetInt16("process_id"),
                order_id = reader.GetInt16("order_id"),
                item = reader.GetString("item"),
                quantity = reader.GetInt16("quantity"),
                operation = reader.GetString("operation"),
                oper_duration = reader.GetTimeSpan(Convert.ToInt32("oper_duration")),
                type = reader.GetString("type"),
            });
        }
        await db.CloseAsync();
        return processes;
    }
    public IEnumerable<Process> Find(Func<Process, bool> predicate)
    {
        throw new NotImplementedException();
    }
}