using PracticeProject.Models.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace PracticeProject.Services
{
    public class PeopleService
    {
        public List<People> SelectAll()
        {
            List<People> peopleList = new List<People>();            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaulConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.People_SelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        People model = Mapper(reader);
                        peopleList.Add(model);
                    }
                }
                conn.Close();
            }
            return peopleList;
        }

        //-PEOPLE MAPPER--
        private People Mapper(SqlDataReader reader)
        {
            People model = new People();
            int index = 0;

            model.Id = reader.GetInt32(index++);
            model.FirstName = reader.GetString(index++);

            if (!reader.IsDBNull(index))
                model.MiddleInitial = reader.GetString(index++);
            else
                index++;  
            
            model.LastName = reader.GetString(index++);
            model.CreatedDate = reader.GetDateTime(index++);
            model.ModifiedDate = reader.GetDateTime(index++);
            model.ModifiedBy = reader.GetString(index++);

            return model;
        }
    }
}
