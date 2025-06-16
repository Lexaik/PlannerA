using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class PersonDbContext : ICrud<Person>
{

    public async Task<bool> InsertAsync(Person instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_persons
                  VALUES (person_id = @person_id,
                          first_name = @first_name,
                          last_name = @last_name,
                          patronymic = @patronymic,
                          date_of_birth = @date_of_birth)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("person_id", instance.person_id);
        command.Parameters.AddWithValue("first_name", instance.first_name);
        command.Parameters.AddWithValue("last_name", instance.last_name);
        command.Parameters.AddWithValue("patronymic", instance.patronymic);
        command.Parameters.AddWithValue("date_of_birth", instance.date_of_birth);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Person instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_persons
                  SET person_id = @person_id,
                      first_name = @first_name,
                      last_name = @last_name,
                      patronymic = @patronymic,
                      date_of_birth = @date_of_birth
                  WHERE person_id = @person_id
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("person_id", instance.person_id);
        command.Parameters.AddWithValue("first_name", instance.first_name);
        command.Parameters.AddWithValue("last_name", instance.last_name);
        command.Parameters.AddWithValue("patronymic", instance.patronymic);
        command.Parameters.AddWithValue("date_of_birth", instance.date_of_birth);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_persons";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var persons = new List<Person>();
        while (await reader.ReadAsync())
        {
            persons.Add(new Person()
            {
                person_id = reader.GetInt16("person_id"),
                first_name = reader.GetString("first_name"),
                last_name = reader.GetString("last_name"),
                patronymic = reader.GetString("patronymic"),
                date_of_birth = reader.GetDateTime("date_of_birth"),
            });
        }
        await db.CloseAsync();
        return persons;
    }
    public IEnumerable<Person> Find(Func<Person, bool> predicate)
    {
        throw new NotImplementedException();
    }
}