using System.Data;
using Npgsql;
using PlannerA.Model;

namespace PlannerA.DAL;

public class WorkerDbContext : ICrud<Worker>
{

    public async Task<bool> InsertAsync(Worker instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  INSERT INTO table_workers
                  VALUES (person_id = @person_id,
                          specialization = @specialization,
                          date_of_hire = @date_of_hire,
                          date_of_separation = @date_of_separation,
                          education = @education,
                          date_of_education_end = @date_of_education_end,
                          department = @department,
                          salary = @salary,
                          is_active = @is_active)
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("person_id", instance.person_id);
        command.Parameters.AddWithValue("specialization", instance.specialization);
        command.Parameters.AddWithValue("date_of_hire", instance.date_of_hire);
        command.Parameters.AddWithValue("date_of_separation", instance.date_of_separation);
        command.Parameters.AddWithValue("education", instance.education);
        command.Parameters.AddWithValue("date_of_education_end", instance.date_of_education_end);
        command.Parameters.AddWithValue("department", instance.department);
        command.Parameters.AddWithValue("salary", instance.salary);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<bool> UpdateAsync(Worker instance)
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = """
                  UPDATE table_workers
                  SET person_id = @person_id,
                      specialization = @specialization,
                      date_of_hire = @date_of_hire,
                      date_of_separation = @date_of_separation,
                      education = @education,
                      date_of_education_end = @date_of_education_end,
                      department = @department,
                      salary = @salary,
                      is_active = @is_active
                  WHERE person_id = @person_id
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("person_id", instance.person_id);
        command.Parameters.AddWithValue("specialization", instance.specialization);
        command.Parameters.AddWithValue("date_of_hire", instance.date_of_hire);
        command.Parameters.AddWithValue("date_of_separation", instance.date_of_separation);
        command.Parameters.AddWithValue("education", instance.education);
        command.Parameters.AddWithValue("date_of_education_end", instance.date_of_education_end);
        command.Parameters.AddWithValue("department", instance.department);
        command.Parameters.AddWithValue("salary", instance.salary);
        command.Parameters.AddWithValue("is_active", instance.is_active);
        var result = command.ExecuteNonQuery();
        await db.CloseAsync();
        
        return result > 0;
    }
    public async Task<IEnumerable<Worker>> GetAllAsync()
    {
        var db = new NpgsqlConnection(AppContext.connectionString);
        await db.OpenAsync();
        var sql = "SELECT * FROM table_workers";
        var cmd = new NpgsqlCommand(sql, db);
        var reader = await cmd.ExecuteReaderAsync();
        var workers = new List<Worker>();
        while (await reader.ReadAsync())
        {
            workers.Add(new Worker()
            {
                person_id = reader.GetInt16("person_id"),
                specialization = reader.GetString("specialization"),
                date_of_hire = reader.GetDateTime("date_of_hire"),
                date_of_separation = reader.IsDBNull("date_of_separation")? null
                    : reader.GetDateTime("date_of_separation"),
                education = reader.IsDBNull("education")? null
                    : reader.GetString("education"),
                date_of_education_end = reader.IsDBNull("date_of_education_end")? null
                    : reader.GetDateTime("date_of_education_end"),
                department = reader.GetString("department"),
                salary = reader.GetDouble("salary"),
                is_active = reader.GetBoolean("is_active"),
            });
        }
        await db.CloseAsync();
        return workers;
    }
    public IEnumerable<Worker> Find(Func<Worker, bool> predicate)
    {
        throw new NotImplementedException();
    }
}