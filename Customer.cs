using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO.NET
{
    internal class Customer
    {
        public static SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; initial catalog= CustomerService; integrated security= true");
        
        public static void InsertRecord()
        {
            try
            {
                CustomerDetails customer = new CustomerDetails();
                Console.WriteLine("Enter Name : ");
                customer.CustomerName = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : ");
                customer.Phone = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Address : ");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Enter Country : ");
                customer.Country = Console.ReadLine();
                Console.WriteLine("Enter Salary : ");
                customer.Salary = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Pincode : ");
                customer.Pincode = Convert.ToInt32(Console.ReadLine());
                con.Open();
                string query = "insert into Customer values('" + customer.CustomerName + "'," + customer.Phone + ",'" + customer.Address + "','" + customer.Country + "'," + customer.Salary + "," + customer.Pincode + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@Salary", customer.Salary);
                cmd.Parameters.AddWithValue("@Pincode", customer.Pincode);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data is inserted Successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }
        public static void RetrieveData()
        {

            try
            {
                CustomerDetails details = new CustomerDetails();
                con.Open();
                string querry = @"select * from Customer";
                SqlCommand command = new SqlCommand(querry, con);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\n>> records retrived from database : ");
                    while (sqlDataReader.Read())
                    {
                        details.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        details.Phone = Convert.ToInt64(sqlDataReader["Phone"]);
                        details.Address = Convert.ToString(sqlDataReader["Address"]);
                        details.Country = Convert.ToString(sqlDataReader["Country"]);
                        details.Salary = Convert.ToInt64(sqlDataReader["Salary"]);
                        details.Pincode = Convert.ToInt32(sqlDataReader["Pincode"]);
                        Console.WriteLine("CustomerName: {0}, Phone: {1}, Address: {2}, Country:{3}, Salary:{4}, Pincode:{5}",
                           details.CustomerName, details.Phone, details.Address, details.Country, details.Salary, details.Pincode);

                    }
                    sqlDataReader.Close();
                }
                else
                {
                    Console.WriteLine("\n>> your database is empty!!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }
        public static void Delete()
        {
            try
            {
                con.Open();
                string query = "delete from Customer Where CustomerName= 'Yogesh Surve'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Deleted From Table");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        public static void Update()
        {
            try
            {
                con.Open();
                string query = "Update Customer set Salary = 80000 Where CustomerName= 'Ram Shinde'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("salary data is updated successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }
    }
}
