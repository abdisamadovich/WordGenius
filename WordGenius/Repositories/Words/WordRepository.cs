using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WordGenius.Constans;
using WordGenius.Entities.Words;
using WordGenius.Interfaces;
using WordGenius.Interfaces.Words;
using WordGenius.Utils;

namespace WordGenius.Repositories.Words;

class WordRepository : IWordsRepository
{
    private readonly NpgsqlConnection _connection;
    public WordRepository()
    {
        _connection = new NpgsqlConnection(DbConstans.DB_CONNECTIONSTRING);
    }

    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Word Obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.words(" +
                "word, tranlate, discription, sound, is_remember, created_at, update_at) " +
                "VALUES(@name, @translate, @discription, @sound, @isremember, @created_at, @updated_at);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                var param = new NpgsqlParameter("@sound", SqlDbType.VarBinary);
                param.Value = Obj.Sounds;
                command.Parameters.AddWithValue("name", Obj.Text);
                command.Parameters.AddWithValue("translate", Obj.Translate);
                command.Parameters.AddWithValue("discription", Obj.Discription);
              //  command.Parameters.AddWithValue("sound", Obj.Sounds);
                command.Parameters.AddWithValue("isremember", Obj.Is_Remember);
                command.Parameters.AddWithValue("created_at", Obj.CreateAt);
                command.Parameters.AddWithValue("updated_at", Obj.UpdateAt); 
                  
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

    public async Task<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"DELETE FROM words  WHERE  id = {Id};";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
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

    public async Task<IList<Word>> GetAllAsync(PagenationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Word>();
            string query = $"select * from words order by id " +
                $"offset {(@params.PageNumber - 1) * @params.PageSize} " +
                $"limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var word = new Word();
                        word.Id = reader.GetInt64(0);
                        word.Text = reader.GetString(1);
                        word.Translate = reader.GetString(2);
                        word.Discription = reader.GetString(3);
                        word.Sounds = (byte[])reader[4];
                        word.Is_Remember = reader.GetBoolean(5);
                        word.CreateAt = reader.GetDateTime(6);
                        word.UpdateAt = reader.GetDateTime(7);
                        list.Add(word);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Word>();
        }
        finally
        {
            await _connection.CloseAsync();
        }


    }

    public async Task<Word> GetAsync(long Id)
    {
        Word word=new Word();   
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from where id = {Id}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        word = new Word();
                        word.Id = reader.GetInt64(0);
                        word.Text = reader.GetString(1);
                        word.Translate = reader.GetString(2);
                        word.Discription = reader.GetString(3);
                        word.Sounds = (byte[])reader[4];
                        //word.Sounds = new Byte[Convert.ToInt32
                        //((reader.GetBytes(4, 0, null, 0, Int32.MaxValue)))];
                        //reader.GetBytes(4, 0, word.Sounds, 0, word.Sounds.Length);
                        word.Is_Remember = reader.GetBoolean(5);
                        word.CreateAt = reader.GetDateTime(6);
                        word.UpdateAt = reader.GetDateTime(7);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);    
        }
        finally
        {
            await _connection.CloseAsync();

        }
        return word;

    }

    public Task<int> UpdateAsync(long Id, Word EditedObj)
    {
        throw new System.NotImplementedException();
    }
}
