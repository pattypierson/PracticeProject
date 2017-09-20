using PracticeProject.Models.Domain;
using PracticeProject.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PracticeProject.Services
{
    public class TeamService : BaseService
    {
        //--SELECT ALL--
        public List<Team> SelectAll()
        {
            List<Team> teamList = new List<Team>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Team_SelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Team model;
                        try
                        {
                            model = Mapper(reader);
                        }
                        catch (Exception ex)
                        {
                            string msg = ex.Message;
                            throw;
                        }
                        teamList.Add(model);
                    }
                }
                conn.Close();
            }
            return teamList;
        }

        //--SELECT BY ID--
        public Team SelectById(int id)
        {
            Team model = new Team();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Team_SelectById", conn))
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

        //--INSERT TEAM--
        public int Insert(TeamAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Team_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamName", model.TeamName);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                    SqlParameter idParameter = new SqlParameter("@Id", SqlDbType.Int);
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
        public void Update(TeamUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Team_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@TeamName", model.TeamName);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

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
                using (SqlCommand cmd = new SqlCommand("dbo.Team_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        //--TEAM MAPPER--SQLDATAREADER--
        private Team Mapper(SqlDataReader reader)
        {
            Team model = new Team();
            int index = 0;

            model.Id = reader.GetInt32(index++);
            model.TeamName = reader.GetString(index++);
            model.CreatedBy = reader.GetString(index++);
            model.CreatedDate = reader.GetDateTime(index++);
            model.ModifiedDate = reader.GetDateTime(index++);

            return model;
        }
    }
}
