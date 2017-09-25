using HtmlAgilityPack;
using PracticeProject.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PracticeProject.Services
{
    public class ScrapeService : BaseService
    {
        public List<string> Scrape(string img)
        {
            var document = new HtmlWeb().Load("https://www.pexels.com/search/" + img);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s));
            List<string> list = urls.ToList();
            List<string> newList = new List<string>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }

        //--INSERT SCRAPED DATA TO DB--
        public List<string> InsertImg(ImageAddRequest model)
        {
            int id = 0;
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Images_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Image", model.Image);
                    cmd.Parameters.AddWithValue("@ImageName", model.ImageName);

                    SqlParameter idParameter = new SqlParameter("@Id", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idParameter);
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }
                conn.Close();
            }
            return list;
        }
    }
}
