using PracticeProject.Models.Domain;
using PracticeProject.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PracticeProject.Services
{
    public class PeopleService : BaseService
    {
        //--SELECT ALL--
        public List<People> SelectAll()
        {
            List<People> peopleList = new List<People>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.People_SelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        People model;
                        try
                        {
                            model = Mapper(reader);
                        }
                        catch (Exception ex)
                        {
                            string msg = ex.Message;
                            throw;
                        }
                        peopleList.Add(model);
                    }
                }
                conn.Close();
            }
            return peopleList;
        }

        //--SELECT BY ID--
        public People SelectById(int id)
        {
            People model = new People();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.People_SelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                        model = Mapper(reader);
                }
                conn.Close();
            }
            return model;
        }

        //--INSERT PERSON--
        public int Insert(PersonAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.People_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    SqlParameter idParameter = new SqlParameter("Id", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idParameter);
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }
                conn.Close();
            }
            return id;
        }

        //--UPDATE--
        public void Update(PersonUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.People_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        //--DELETE--
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.People_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        //--PEOPLE MAPPER--SQLDATAREADER--
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
