using EiaApiIntegrationService.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using EiaApiIntegrationService.Constants;
using System.Data;
using System.Linq;

namespace EiaApiIntegrationService.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private string _connectionString;
        public SeriesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<SeriesData> GetList(DateTime startDate, DateTime endDate)
        {
            var result = new List<SeriesData>();

            using (var db = new SqlConnection(_connectionString))
            {
                result = db.Query<SeriesData>(RepositoryConstants.Series_GetList,
                    new
                    {
                        StartDate = startDate,
                        EndDate = endDate
                    }, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

        public void Save(DateTime createdDate, decimal value, bool isDelete)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Query<SeriesData>(RepositoryConstants.Series_GetList,
                    new
                    {
                        CreatedDate = createdDate,
                        Value = value,
                        IsDelete = isDelete
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
