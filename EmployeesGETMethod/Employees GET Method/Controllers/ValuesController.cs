using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Employees_GET_Method.Controllers
{
    public class ValuesController : ApiController
    {   
   SqlConnection con = new SqlConnection(@"server=DESKTOP-536S0EI\SQLEXPRESS ; database=databaseEMPO; Integrated Security=true;");

        // GET api/values
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from EmployDATA1" , con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }
        // GET api/values
        public string Get(int id)
        {
            //return "values";
            SqlDataAdapter da = new SqlDataAdapter("select * from EmployDATA1 WHERE id = '"+id+"' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }


        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("Insert into EmployDATA1(LastName) VALUES('" + value + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i == 1)
            {
                return "Record inserted with the value as " + value;
            }
            else
            {
                return "Try again. No data inserted";
            }
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("UPDATE  EmployDATA1 SET LastName = '" + value + "' WHERE ID ='" + id + "' ", con);

            //SqlCommand cmd = new SqlCommand("update  EmployDATA1 set FirstName = 'Konali' where ID = 7" ,con);
  
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record updated with the value as " + value+ "and id as" +id;
            }
            else
            {
                return "Try again. No data updated";
            }
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM  EmployDATA1 WHERE ID ='" + id + "' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record deleted with the  id as" + id;
            }
            else
            {
                return "Try again. No data deleted";
            }
        }
    }
}
