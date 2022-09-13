using CustomerRepositoryPattern.Entities;
using CustomerRepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerRepositoryPattern.Repositories
{
    public class CustomerRepository : ServerOptions, IRepository<Customer>
    {
        public int Create(Customer customer)
        {
            int customerId;

            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO [Customer] (FirstName, LastName, PhoneNumber, Email, Notes, TotalPurchasesAmount) " +

                    "VALUES(@FirstName, @LastName, @PhoneNumber, @Email, @Notes, @TotalPurchasesAmount) " +
                    " SELECT CAST(scope_identity() AS int)", connection);

                var FirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.FirstName
                };
                var LastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.LastName
                };
                var PhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = customer.PhoneNumber
                };
                var EmailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
                {
                    Value = customer.Email
                };
                var NotesParam = new SqlParameter("@Notes", SqlDbType.NVarChar, 250)
                {
                    Value = customer.Email
                };
                var TotalPurchaseAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
                {
                    Value = customer.TotalPurchasesAmount
                };

                command.Parameters.Add(FirstNameParam);
                command.Parameters.Add(LastNameParam);
                command.Parameters.Add(PhoneNumberParam);
                command.Parameters.Add(EmailParam);
                command.Parameters.Add(NotesParam);
                command.Parameters.Add(TotalPurchaseAmountParam);


                customerId = (Int32)command.ExecuteScalar();
            }

            return customerId;
        }

        public Customer Read(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customer] WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Customer()
                        {
                            CustomerId = (Int32)reader["CustomerId"],
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString(),
                            PhoneNumber = reader["PhoneNumber"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Notes = reader["Notes"].ToString(),
                            TotalPurchasesAmount = (decimal)reader["TotalPurchasesAmount"]
                        };
                    }
                }
            }

            return null;
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Customer]", connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer()
                        {
                            CustomerId = (Int32)reader["CustomerId"],
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString(),
                            PhoneNumber = reader["PhoneNumber"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Notes = reader["Notes"]?.ToString(),
                            TotalPurchasesAmount = (decimal)reader["TotalPurchasesAmount"]
                        });
                    }
                }
            }
            return customers;
        }

        public void Update(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Customer] SET FirstName=@FirstName, LastName=@LastName, PhoneNumber=@PhoneNumber, " +
                    "Email=@Email, Notes=@Notes, TotalPurchasesAmount=@TotalPurchasesAmount" +
                    " WHERE CustomerId=@CustomerId", connection);
                var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customer.CustomerId
                };
                var FirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.FirstName
                };
                var LastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.LastName
                };
                var PhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = customer.PhoneNumber
                };
                var EmailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
                {
                    Value = customer.Email
                };
                var NotesParam = new SqlParameter("@Notes", SqlDbType.NVarChar, 250)
                {
                    Value = customer.Notes
                };
                var TotalPurchaseAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
                {
                    Value = customer.TotalPurchasesAmount
                };

                command.Parameters.Add(CustomerIdParam);
                command.Parameters.Add(FirstNameParam);
                command.Parameters.Add(LastNameParam);
                command.Parameters.Add(PhoneNumberParam);
                command.Parameters.Add(EmailParam);
                command.Parameters.Add(NotesParam);
                command.Parameters.Add(TotalPurchaseAmountParam);


                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entityId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [Customer] WHERE CustomerId = @CustomerId", connection);
                var customerIDParam = new SqlParameter("@CustomerId", SqlDbType.Int)
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
                var command = new SqlCommand("DELETE FROM [Customer]", connection);

                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            using (var connection = GetConnection())
            {
                var customers = new List<Customer>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customer]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Notes = reader["Notes"].ToString(),
                            TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"])
                        });
                    }
                }
                return customers;
            }
        }

        public List<Customer> GetCustomerAddresses(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
