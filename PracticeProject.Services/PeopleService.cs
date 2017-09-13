using PracticeProject.Data.Providers;
using PracticeProject.Models.Domain;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PracticeProject.Services
{
    public class PeopleService : BaseService, IPeopleService
    {
        public PeopleService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        //public List<People> SelectAll()
        //{
        //    List<People> peopleList = new List<People>();            
        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaulConnection"].ConnectionString))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("dbo.People_SelectAll", conn))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //            while (reader.Read())
        //            {
        //                People model = Mapper(reader);
        //                peopleList.Add(model);
        //            }
        //        }
        //        conn.Close();
        //    }
        //    return peopleList;
        //}

        public List<People> Get()
        {
            List<People> list = new List<People>();
            DataProvider.ExecuteCmd("dbo.People_SelectAll"
                , inputParamMapper: null
                , singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    People singleItem = Mapper(reader);
                    list.Add(singleItem);
                });
            return list;
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

        //--PEOPLE MAPPER--IDATAREADER--
        private People Mapper(IDataReader reader)
        {
            People singleItem = new People();
            int startingIndex = 0; //startingOrdinal

            singleItem.Id = reader.GetInt32(startingIndex++);
            singleItem.FirstName = reader.GetString(startingIndex++);
            singleItem.MiddleInitial = reader.GetString(startingIndex++);
            singleItem.LastName = reader.GetString(startingIndex++);
            singleItem.CreatedDate = reader.GetDateTime(startingIndex++);
            singleItem.ModifiedDate = reader.GetDateTime(startingIndex++);
            singleItem.ModifiedBy = reader.GetString(startingIndex++);
            return singleItem;
        }
    }
}
