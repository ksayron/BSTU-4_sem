using D_D_CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;

namespace D_D_CharacterSheet.Data
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public void EnsureDatabaseCreated()
        {

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand("IF DB_ID('DnDCharacters') IS NULL CREATE DATABASE DnDCharacters;", conn);
            cmd.ExecuteNonQuery();

            conn.ChangeDatabase("DnDCharacters");

            // Create tables if not exist
            var createUsers = @"
            IF OBJECT_ID('Users') IS NULL
            CREATE TABLE Users (
                Id INT PRIMARY KEY IDENTITY,
                Username NVARCHAR(100) NOT NULL UNIQUE,
                Password NVARCHAR(100) NOT NULL
            );";
            var createCharacters = @"
            IF OBJECT_ID('Characters') IS NULL
            CREATE TABLE Characters (
                Id INT PRIMARY KEY IDENTITY,
                Name NVARCHAR(100),
                Race NVARCHAR(100),
                Class NVARCHAR(100),
                Level INT,
                UserId INT FOREIGN KEY REFERENCES Users(Id)
            );";

            new SqlCommand(createUsers, conn).ExecuteNonQuery();
            new SqlCommand(createCharacters, conn).ExecuteNonQuery();
        }

        public bool RegisterUser(string username, string password)
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            var tr = conn.BeginTransaction();
            try
            {
               
                var query = "INSERT INTO Users (Username, Password) OUTPUT INSERTED.Id VALUES (@Username, @Password)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteScalar();
                tr.Commit();
                return true;
            }
            catch
            {
                tr.Rollback();
                return false;
            }
        }

        public User? AuthenticateUser(string username, string password)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var query = "SELECT Id FROM Users WHERE Username = @Username AND Password = @Password";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Userame = reader["Username"].ToString()
                };
            }
            return null;
        }

        public List<Character> GetCharactersByUser(int userId)
        {
            var characters = new List<Character>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var query = "SELECT * FROM Characters WHERE UserId = @UserId";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                characters.Add(new Character
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Race = reader["Race"].ToString(),
                    Class = reader["Class"].ToString(),
                    Level = (int)reader["Level"],
                    UserId = (int)reader["UserId"]
                });
            }

            return characters;
        }

        public void AddCharacter(Character character)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var tr = conn.BeginTransaction();

            var query = @"
            INSERT INTO Characters (Name, Race, Class, Level, UserId)
            VALUES (@Name, @Race, @Class, @Level, @UserId)";

            using var cmd = new SqlCommand(query, conn, tr);
            cmd.Parameters.AddWithValue("@Name", character.Name);
            cmd.Parameters.AddWithValue("@Race", character.Race);
            cmd.Parameters.AddWithValue("@Class", character.Class);
            cmd.Parameters.AddWithValue("@Level", character.Level);
            cmd.Parameters.AddWithValue("@UserId", character.UserId);

            cmd.ExecuteNonQuery();
            tr.Commit();
        }

        public void UpdateCharacter(Character character)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tr = conn.BeginTransaction();
            var query = @"
            UPDATE Characters SET 
                Name = @Name, 
                Race = @Race, 
                Class = @Class, 
                Level = @Level 
            WHERE Id = @Id AND UserId = @UserId";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", character.Name);
            cmd.Parameters.AddWithValue("@Race", character.Race);
            cmd.Parameters.AddWithValue("@Class", character.Class);
            cmd.Parameters.AddWithValue("@Level", character.Level);
            cmd.Parameters.AddWithValue("@Id", character.Id);
            cmd.Parameters.AddWithValue("@UserId", character.UserId);

            cmd.ExecuteNonQuery();
            tr.Commit();
        }

        public void DeleteCharacter(int characterId, int userId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var tr = conn.BeginTransaction();

            var query = "DELETE FROM Characters WHERE Id = @Id AND UserId = @UserId";
            using var cmd = new SqlCommand(query, conn, tr);
            cmd.Parameters.AddWithValue("@Id", characterId);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();
            tr.Commit();
        }

        public List<Character> SearchCharactersByName(int userId, string namePart)
        {
            var characters = new List<Character>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var query = @"
            SELECT * FROM Characters 
            WHERE UserId = @UserId AND Name LIKE @NamePattern";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@NamePattern", "%" + namePart + "%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                characters.Add(new Character
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Race = reader["Race"].ToString(),
                    Class = reader["Class"].ToString(),
                    Level = (int)reader["Level"],
                    UserId = (int)reader["UserId"]
                });
            }

            return characters;
        }
    }
}
