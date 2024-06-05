using Motorcycles.Repository.Common;
using Motorcycles.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Motorcycles.Repository
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly string _connectionString;

        public MotorcycleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        public void AddMotorcycle(Motorcycle motorcycle)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        INSERT INTO ""Motorcycle"" (""Make"", ""Model"", ""Year"", ""IsDeleted"", ""CreatedByUserId"", ""UpdatedByUserId"", ""DateCreated"", ""DateUpdated"")
                        VALUES (@Make, @Model, @Year, @IsDeleted, @CreatedByUserId, @UpdatedByUserId, @DateCreated, @DateUpdated)";

                    command.Parameters.AddWithValue("Make", (object?)motorcycle.Make ?? DBNull.Value);
                    command.Parameters.AddWithValue("Model", (object?)motorcycle.Model ?? DBNull.Value);
                    command.Parameters.AddWithValue("Year", motorcycle.Year);
                    command.Parameters.AddWithValue("IsDeleted", motorcycle.IsDeleted);
                    command.Parameters.AddWithValue("CreatedByUserId", motorcycle.CreatedByUserId);
                    command.Parameters.AddWithValue("UpdatedByUserId", motorcycle.UpdatedByUserId);
                    command.Parameters.AddWithValue("DateCreated", motorcycle.DateCreated);
                    command.Parameters.AddWithValue("DateUpdated", motorcycle.DateUpdated);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMotorcycle(Motorcycle motorcycle)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        UPDATE ""Motorcycle""
                        SET ""Make"" = @Make, ""Model"" = @Model, ""Year"" = @Year, ""IsDeleted"" = @IsDeleted,
                            ""CreatedByUserId"" = @CreatedByUserId, ""UpdatedByUserId"" = @UpdatedByUserId,
                            ""DateCreated"" = @DateCreated, ""DateUpdated"" = @DateUpdated
                        WHERE ""Id"" = @Id";

                    command.Parameters.AddWithValue("Make", (object?)motorcycle.Make ?? DBNull.Value);
                    command.Parameters.AddWithValue("Model", (object?)motorcycle.Model ?? DBNull.Value);
                    command.Parameters.AddWithValue("Year", motorcycle.Year);
                    command.Parameters.AddWithValue("IsDeleted", motorcycle.IsDeleted);
                    command.Parameters.AddWithValue("CreatedByUserId", motorcycle.CreatedByUserId);
                    command.Parameters.AddWithValue("UpdatedByUserId", motorcycle.UpdatedByUserId);
                    command.Parameters.AddWithValue("DateCreated", motorcycle.DateCreated);
                    command.Parameters.AddWithValue("DateUpdated", motorcycle.DateUpdated);
                    command.Parameters.AddWithValue("Id", motorcycle.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMotorcycle(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM ""Motorcycle"" WHERE ""Id"" = @Id";
                    command.Parameters.AddWithValue("Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Motorcycle GetMotorcycle(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM ""Motorcycle"" WHERE ""Id"" = @Id";
                    command.Parameters.AddWithValue("Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Motorcycle
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Make = reader.GetString(reader.GetOrdinal("Make")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Year = reader.GetInt32(reader.GetOrdinal("Year")),
                                IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                CreatedByUserId = reader.GetInt32(reader.GetOrdinal("CreatedByUserId")),
                                UpdatedByUserId = reader.GetInt32(reader.GetOrdinal("UpdatedByUserId")),
                                DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                                DateUpdated = reader.GetDateTime(reader.GetOrdinal("DateUpdated"))
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Motorcycle> GetMotorcyclesByUserName(string firstName, string lastName)
        {
            var motorcycles = new List<Motorcycle>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        SELECT m.* 
                        FROM ""Motorcycle"" m
                        INNER JOIN ""User"" u ON m.""CreatedByUserId"" = u.""Id"" OR m.""UpdatedByUserId"" = u.""Id""
                        WHERE u.""FirstName"" = @FirstName AND u.""LastName"" = @LastName";

                    command.Parameters.AddWithValue("FirstName", firstName);
                    command.Parameters.AddWithValue("LastName", lastName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            motorcycles.Add(new Motorcycle
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Make = reader.GetString(reader.GetOrdinal("Make")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Year = reader.GetInt32(reader.GetOrdinal("Year")),
                                IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                CreatedByUserId = reader.GetInt32(reader.GetOrdinal("CreatedByUserId")),
                                UpdatedByUserId = reader.GetInt32(reader.GetOrdinal("UpdatedByUserId")),
                                DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                                DateUpdated = reader.GetDateTime(reader.GetOrdinal("DateUpdated"))
                            });
                        }
                    }
                }
            }

            return motorcycles;
        }
    }
}
