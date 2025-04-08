using Npgsql;
using System.Data;
using PlannerA.Model;

namespace PlannerA.DAL;

public class DBContext : ICrud
{
    private const string ConnectionString = "Server=127.0.0.1;Port=5432;Database=plannerA;User Id=postgres;Password=1234;SearchPath=test";
    
    public bool Insert(Item item)
    {
        throw new NotImplementedException();
    }

    public bool Update(Item item)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Item item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> GetAll()
    {
        var db = new NpgsqlConnection(ConnectionString);
        db.Open();
        var sql = "SELECT * FROM table_items";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = cmd.ExecuteReader();
        var items = new List<Item>();
        while (reader.Read())
        {
            items.Add(new Item()
            {
                name = reader.GetString("name"),
                date_of_produce = reader.GetDateTime("date_of_produce"),
                parameters = reader.GetString("parameters"),
                price = reader.GetDouble("price"),
                is_active = reader.GetBoolean("is_active"),
            });
        }
        db.Close();
        return items;
    }
}