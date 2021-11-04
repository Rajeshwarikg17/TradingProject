using ApplicationEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ApplicationDAL
{
    public class DALService
    {
        static string connectionString = "Data Source=.;Initial Catalog=Sample;Integrated Security=True";
        public static void SaveCustomerDetails(Customer cust)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                SqlCommand comm = new SqlCommand($"insert into Customer values('{cust.TradingPartnerName}','{cust.City}',{cust.CreditLimit},'{cust.EmailId}')", conn);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }

            }

        }

        public static void SaveSupplierDetails(Supplier supp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                SqlCommand comm = new SqlCommand($"insert into Supplier values('{supp.TradingPartnerName}','{supp.City}',{supp.CreditBalance},'{supp.PanNo}')", conn);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }

            }

        }

        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Customer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);


                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Customer c = new Customer();
                    string TradingPartnerId = row["TradingPartnerId"].ToString();
                    string TradingPartnerName = row["TradingPartnerName"].ToString();
                    string City = row["City"].ToString();
                    string CreditLimit = row["CreditLimit"].ToString();
                    string emailId = row["emailId"].ToString();

                    c.TradingPartnerId = Convert.ToInt32(TradingPartnerId);
                    c.TradingPartnerName = TradingPartnerName;
                    c.City = City;
                    c.CreditLimit = Convert.ToInt32(CreditLimit);
                    c.EmailId = emailId;
                    customers.Add(c);
                }
                da.Dispose();
            }

            return customers;


        }

        public static List<Supplier> GetAllSuppliers()
        {
            var suppliers = new List<Supplier>();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Supplier";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);


                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Supplier s = new Supplier();
                    string TradingPartnerId = row["TradingPartnerId"].ToString();
                    string TradingPartnerName = row["TradingPartnerName"].ToString();
                    string City = row["City"].ToString();
                    string CreditBalance = row["CreditBalance"].ToString();
                    string PanNo = row["PanNo"].ToString();

                    s.TradingPartnerId = Convert.ToInt32(TradingPartnerId);
                    s.TradingPartnerName = TradingPartnerName;
                    s.City = City;
                    s.CreditBalance = Convert.ToInt32(CreditBalance);
                    s.PanNo = PanNo;
                    suppliers.Add(s);
                }
                da.Dispose();
            }

            return suppliers;


        }

        public static Customer GetCustomerById(int customerid)
        {
            DataTable dataTable = new DataTable();
            string query = $"SELECT * FROM Customer where TradingPartnerId={customerid}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);


                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                Customer c = new Customer();
                foreach (DataRow row in dataTable.Rows)
                {

                    string TradingPartnerId = row["TradingPartnerId"].ToString();
                    string TradingPartnerName = row["TradingPartnerName"].ToString();
                    string City = row["City"].ToString();
                    string CreditLimit = row["CreditLimit"].ToString();
                    string emailId = row["emailId"].ToString();

                    c.TradingPartnerId = Convert.ToInt32(TradingPartnerId);
                    c.TradingPartnerName = TradingPartnerName;
                    c.City = City;
                    c.CreditLimit = Convert.ToInt32(CreditLimit);
                    c.EmailId = emailId;

                }
                da.Dispose();
                return c;

            }

        }

        public static Supplier GetSupplierById(int supplierid)
        {
            DataTable dataTable = new DataTable();
            string query = $"SELECT * FROM Supplier where TradingPartnerId={supplierid}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);


                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                Supplier s = new Supplier();
                foreach (DataRow row in dataTable.Rows)
                {

                    string TradingPartnerId = row["TradingPartnerId"].ToString();
                    string TradingPartnerName = row["TradingPartnerName"].ToString();
                    string City = row["City"].ToString();
                    string CreditBalance = row["CreditBalance"].ToString();
                    string PanNo = row["PanNo"].ToString();

                    s.TradingPartnerId = Convert.ToInt32(TradingPartnerId);
                    s.TradingPartnerName = TradingPartnerName;
                    s.City = City;
                    s.CreditBalance = Convert.ToInt32(CreditBalance);
                    s.PanNo = PanNo;
                }
                da.Dispose();
                return s;

            }

        }
    }

}

