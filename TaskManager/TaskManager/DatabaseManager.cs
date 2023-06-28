using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;
using TaskManager.Models;

namespace TaskManager;


public class DatabaseManager
{
    private readonly string _connectionString;

    public DatabaseManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public TaskModel ShowTask(TaskModel taskModel)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        string query = "SELECT * FROM TaskModel;";

        List<TaskModel> items = connection.Query<TaskModel>(query).ToList();
        return taskModel;
    }

    public void CreateTask(TaskModel taskModel) 
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "INSERT INTO TaskModels ( Title, Description , Priority, Status) " +
            "VALUES ( @Title, @Description, @Priority, @Status)";
        connection.Execute(query, taskModel);
    }
    public void DeleteTask(TaskModel taskModel)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "DELETE FROM TaskModels" +
            "  Where Id = @Id"; 
        connection.Execute(query, taskModel);
    }
    public void UpdateTask()
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        Console.WriteLine("Введите имя таблицы: ");
            string tableName = Console.ReadLine();

            Console.WriteLine("Введите имя столбца: ");
            string columnName = Console.ReadLine();

            Console.WriteLine("Введите новое значение: ");
            string newValue = Console.ReadLine();

            Console.WriteLine("Введите условие: ");
            string condition = Console.ReadLine();

            string query = $"UPDATE {tableName} SET {columnName} = @NewValue WHERE {condition}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NewValue", newValue);
                command.ExecuteNonQuery();
            }
        }
    }
