using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class EquipmentDbContext : ICrud<Equipment>
{
    public async Task<bool> InsertAsync(Equipment instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_equipments
                  VALUES (equipment_id = @equipment_id,
                          name = @name,
                          type = @type,
                          model = @model,
                          manufacturer = @manufacturer,
                          description = @description,
                          price = @price,
                          date_of_purchase = @date_of_purchase,
                          department = @department,
                          is_active = @is_active)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("equipment_id", instance.equipment_id);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("type", instance.type);
        command.Parameters.AddWithValue("model", instance.model);
        command.Parameters.AddWithValue("manufacturer", instance.manufacturer);
        command.Parameters.AddWithValue("description", instance.description);
        command.Parameters.AddWithValue("price", instance.price);
        command.Parameters.AddWithValue("date_of_purchase", instance.date_of_purchase);
        command.Parameters.AddWithValue("department", instance.department);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Equipment instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_equipments
                  SET equipment_id = @equipment_id,
                  name = @name,
                  type = @type,
                  model = @model,
                  manufacturer = @manufacturer,
                  description = @description,
                  price = @price,
                  date_of_purchase = @date_of_purchase,
                  department = @department,
                  is_active = @is_active
                  WHERE equipment_id = @equipment_id
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("equipment_id", instance.equipment_id);
        command.Parameters.AddWithValue("name", instance.name);
        command.Parameters.AddWithValue("type", instance.type);
        command.Parameters.AddWithValue("model", instance.model);
        command.Parameters.AddWithValue("manufacturer", instance.manufacturer);
        command.Parameters.AddWithValue("description", instance.description);
        command.Parameters.AddWithValue("price", instance.price);
        command.Parameters.AddWithValue("date_of_purchase", instance.date_of_purchase);
        command.Parameters.AddWithValue("department", instance.department);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Equipment>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_equipments";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var equipments = new List<Equipment>();
        while (await reader.ReadAsync())
        {
            equipments.Add(new Equipment()
            {
                equipment_id = reader.GetInt16("equipment_id"),
                name = reader.GetString("name"),
                type = reader.GetString("type"),
                model = reader.GetString("model"),
                manufacturer = reader.GetString("manufacturer"),
                description = reader.IsDBNull("description")? null
                    : reader.GetString("description"),
                price = reader.GetDouble("price"),
                date_of_purchase = reader.GetDateTime("date_of_purchase"),
                department = reader.GetString("department"),
                is_active = reader.GetBoolean("is_active"),
            });
        }
        await db.CloseAsync();
        return equipments;
    }
    public IEnumerable<Equipment> Find(Func<Equipment, bool> predicate)
    {
        throw new NotImplementedException();
    }
}