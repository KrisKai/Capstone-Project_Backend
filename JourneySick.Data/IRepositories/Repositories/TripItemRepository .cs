using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripItemRepository : BaseRepository, ITripItemRepository
    {
        public TripItemRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Tbltripitem>> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                itemId ??= "";
                parameters.Add("itemId", itemId, DbType.String);

                var query = "SELECT * FROM tbltripitem WHERE fldItemId LIKE CONCAT('%', @itemId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbltripitem>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltripitem> GetTripItemById(int tripItemId)
        {
            try
            {
                var query = "SELECT * FROM tbltripitem WHERE fldItemId = @fldItemId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", tripItemId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltripitem>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTripItems(string? itemId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbltripitem WHERE fldItemId LIKE CONCAT('%', @itemId, '%')";

                itemId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("itemId", itemId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateTripItem(Tbltripitem tbltripitem)
        {
            try
            {
                var query = "INSERT INTO tbltripitem ("
                    + "         fldTripId, "
                    + "         fldItemName, "
                    + "         fldItemDescription, "
                    + "         fldPriceMin, "
                    + "         fldPriceMax, "
                    + "         fldItemCategory, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldItemName, "
                    + "         @fldItemDescription, "
                    + "         @fldPriceMin, "
                    + "         @fldPriceMax, "
                    + "         @fldItemCategory, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripitem.FldTripId, DbType.String);
                parameters.Add("fldItemName", tbltripitem.FldItemName, DbType.String);
                parameters.Add("fldItemDescription", tbltripitem.FldItemDescription, DbType.String);
                parameters.Add("fldPriceMin", tbltripitem.FldPriceMin, DbType.String);
                parameters.Add("fldPriceMax", tbltripitem.FldPriceMax, DbType.String);
                parameters.Add("fldItemCategory", tbltripitem.FldItemCategory, DbType.String);
                parameters.Add("fldCreateDate", tbltripitem.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tbltripitem.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateTripItem(Tbltripitem tbltripitem)
        {
            try
            {
                var query = "UPDATE tbltripitem SET " +
                    "fldItemName = @fldItemName, " +
                    "fldItemDescription = @fldItemDescription, " +
                    "fldPriceMin = @fldPriceMin, " +
                    "fldPriceMax = @fldPriceMax, " +
                    "fldItemCategory = @fldItemCategory, " +
                    "fldUpdateDate = @fldUpdateDate, " +
                    "fldUpdateBy = @fldUpdateBy " +
                    "WHERE fldItemId = @fldItemId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", tbltripitem.FldItemId, DbType.String);
                parameters.Add("fldItemName", tbltripitem.FldItemName, DbType.String);
                parameters.Add("fldItemDescription", tbltripitem.FldItemDescription, DbType.String);
                parameters.Add("fldPriceMin", tbltripitem.FldPriceMin, DbType.String);
                parameters.Add("fldPriceMax", tbltripitem.FldPriceMax, DbType.String);
                parameters.Add("fldItemCategory", tbltripitem.FldItemCategory, DbType.String);
                parameters.Add("fldUpdateDate ", tbltripitem.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tbltripitem.FldUpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripItem(int tripItemId)
        {
            try
            {
                var query = "DELETE FROM tbltripitem WHERE fldItemId = @fldItemId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", tripItemId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


    }
}
