using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerRepositoryPattern.Repositories
{
    public class AddressRepository : ServerOptions, IRepository<Address>
    {
        public int Create(Address address)
        {
            int addressId;
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO [Address] (CustomerId, AddressLine, AddressLine2, AddressType, City, PostalCode, [State], Country) " +

                    "VALUES(@CustomerId, @AddressLine, @AddressLine2, @AddressType, @City, @PostalCode, @state, @Country) " +
                    "SELECT CAST(scope_identity() AS int)", connection);

                var CustomerId = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = address.CustomerId
                };
                var AddressLine = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine
                };
                var AddressLine2 = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine2
                };
                var City = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = address.City
                };
                var PostalCode = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = address.PostalCode
                };
                var State = new SqlParameter("@State", SqlDbType.NVarChar, 20)
                {
                    Value = address.State
                };
                var AddressType = new SqlParameter("@AddressType", SqlDbType.NVarChar, 8)
                {
                    Value = address.AddressType
                };
                var Country = new SqlParameter("@Country", SqlDbType.NVarChar, 30)
                {
                    Value = address.Country
                };

                command.Parameters.Add(CustomerId);
                command.Parameters.Add(AddressLine);
                command.Parameters.Add(AddressLine2);
                command.Parameters.Add(AddressType);
                command.Parameters.Add(City);
                command.Parameters.Add(PostalCode);
                command.Parameters.Add(State);
                command.Parameters.Add(Country);


                addressId = (Int32)command.ExecuteScalar();
            }

            return addressId;
        }

        public Address Read(int addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Address] WHERE AddressId = @AddressId", connection);

                var AddressIdParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = addressId
                };

                command.Parameters.Add(AddressIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var addressType = reader["AddressType"]?.ToString();

                        if (addressType != null)
                        {
                            return new Address()
                            {
                                CustomerId = (Int32)reader["CustomerId"],
                                AddressLine = reader["AddressLine"].ToString(),
                                AddressLine2 = reader["AddressLine2"].ToString(),
                                AddressType = reader["AddressType"].ToString(),
                                City = reader["City"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                State = reader["state"].ToString(),
                                Country = reader["Country"].ToString()
                            };
                        }
                    }
                }
            }

            return null;

        }
        
        public List<Address> ReadAll()
        {
            List<Address> foundAddresses = new List<Address>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Address] WHERE AddressId = @AddressId", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var addressType = reader["AddressType"]?.ToString();

                        if (addressType != null)
                        {
                            foundAddresses.Add(new Address()
                            {
                                CustomerId = (Int32)reader["CustomerId"],
                                AddressLine = reader["AddressLine"].ToString(),
                                AddressLine2 = reader["AddressLine2"].ToString(),
                                AddressType = reader["AddressType"].ToString(),
                                City = reader["City"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                State = reader["State"].ToString(),
                                Country = reader["Country"].ToString()
                            });
                        }


                    }
                }
            }

            return foundAddresses;
        }

        public void Update(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Address] SET CustomerId=@CustomerId, AddressLine = @AddressLine, AddressLine2 = @AddressLine2, AddressType = @AddressType, " +
                    "City = @City, PostalCode = @PostalCode, [State] = @State, Country = @Country " +
                    "WHERE AddressId = @AddressId", connection);
                command.Parameters.Add(new SqlParameter("@AddressId", SqlDbType.Int) { Value = address.AddressId});
                command.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.Int) { Value = address.CustomerId});
                command.Parameters.Add(new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100) { Value = address.AddressLine });
                command.Parameters.Add(new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100) { Value = address.AddressLine2 });
                command.Parameters.Add(new SqlParameter("@AddressType", SqlDbType.VarChar, 8) { Value = address.AddressType});
                command.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 50) { Value = address.City });
                command.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar, 6) { Value = address.PostalCode });
                command.Parameters.Add(new SqlParameter("@State", SqlDbType.NVarChar, 20) { Value = address.State });
                command.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 255) { Value = address.Country });

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entityId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [Address] WHERE AddressId = @AddressId", connection);
                var customerIDParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = entityId
                };
                command.Parameters.Add(customerIDParam);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [Address]", connection);

                command.ExecuteNonQuery();
            }
        }

        public List<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Address", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return addresses;
            }
        }

    }
}
