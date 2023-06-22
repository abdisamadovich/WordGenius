using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGenius.Entities.Results;
using WordGenius.Interfaces.Results;
using System.Windows;

namespace WordGenius.Repositories.Results;

class ResultRepository : BaseRepository, IResultsRepository
{
  
    public async Task<int> CreateAsync(Result Obj)
    { 
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO results " +
                "(words_id, step_1, step_2, step_3)  " +
                "VALUES(@words_id, @step_1, @step_2, @step_3); ";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("words_id", Obj.WordsId);
                command.Parameters.AddWithValue("step_1", Obj.Step1);
                command.Parameters.AddWithValue("step_2", Obj.Step2);
                command.Parameters.AddWithValue("step_3", Obj.Step3);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Result> GetAsync(long id)
    {
        Result result = new Result();
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from where id = {id}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Id = reader.GetInt64(0);
                        result.WordsId = reader.GetInt64(1);
                        result.Step1 = reader.GetDateTime(2);
                        result.Step2 = reader.GetDateTime(3);
                        result.Step3 = reader.GetDateTime(4);
                    }
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return new Result();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }

    public Task<int> UpdateStepAsync(Result Obj, int StepNumber)
    {
        throw new NotImplementedException();
    }
}
