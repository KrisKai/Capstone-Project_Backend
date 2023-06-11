using Dapper;
using JourneySick.Data.Helpers;
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

        public async Task<List<TripItem>> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId, string tripId)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int32);
                parameters.Add("lastIndex", lastIndex, DbType.Int32);
                itemId ??= "";
                parameters.Add("itemId", itemId, DbType.String);
                parameters.Add("categoryId", categoryId, DbType.Int32);
                parameters.Add("tripId", tripId, DbType.String);
                var query = "";
                if (categoryId == 0)
                {
                    query = "SELECT * FROM trip_item WHERE TripId = @tripId AND ItemId LIKE CONCAT('%', @itemId, '%') LIMIT @firstIndex, @lastIndex";
                }
                else
                {
                    query = "SELECT * FROM trip_item WHERE TripId = @tripId AND ItemId LIKE CONCAT('%', @itemId, '%') AND CategoryId = @categoryId LIMIT @firstIndex, @lastIndex";
                }

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripItem>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TripItem> GetTripItemById(int tripItemId)
        {
            try
            {
                var query = "SELECT * FROM trip_item WHERE ItemId = @ItemId";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", tripItemId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripItem>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTripItems(string? itemId, int categoryId, string tripId)
        {
            try
            {
                var query = "";
                if (categoryId == 0)
                {
                    query = "SELECT COUNT(*) FROM trip_item WHERE TripId = @tripId AND ItemId LIKE CONCAT('%', @itemId, '%')";
                }
                else
                {
                    query = "SELECT COUNT(*) FROM trip_item WHERE TripId = @tripId AND ItemId LIKE CONCAT('%', @itemId, '%')";
                }
                itemId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("itemId", itemId, DbType.String);
                parameters.Add("categoryId", categoryId, DbType.Int32);
                parameters.Add("tripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateTripItem(TripItem tripitem)
        {
            try
            {
                var query = "INSERT INTO trip_item ("
                    + "         TripId, "
                    + "         ItemName, "
                    + "         ItemDescription, "
                    + "         PriceMin, "
                    + "         PriceMax, "
                    + "         CategoryId, "
                    + "         Quantity, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @ItemName, "
                    + "         @ItemDescription, "
                    + "         @PriceMin, "
                    + "         @PriceMax, "
                    + "         @ItemCategory, "
                    + "         @Quantity, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripitem.TripId, DbType.String);
                parameters.Add("ItemName", tripitem.ItemName, DbType.String);
                parameters.Add("ItemDescription", tripitem.ItemDescription, DbType.String);
                parameters.Add("PriceMin", tripitem.PriceMin, DbType.Decimal);
                parameters.Add("PriceMax", tripitem.PriceMax, DbType.Decimal);
                parameters.Add("ItemCategory", tripitem.CategoryId, DbType.Int32);
                parameters.Add("Quantity", tripitem.Quantity, DbType.Int32);
                parameters.Add("CreateDate", tripitem.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", tripitem.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateTripItem(TripItem tripitem)
        {
            try
            {
                var query = "UPDATE trip_item SET " +
                    "ItemName = @ItemName, " +
                    "ItemDescription = @ItemDescription, " +
                    "PriceMin = @PriceMin, " +
                    "PriceMax = @PriceMax, " +
                    "CategoryId = @ItemCategory, " +
                    "Quantity = @Quantity, " +
                    "UpdateDate = @UpdateDate, " +
                    "UpdateBy = @UpdateBy " +
                    "WHERE ItemId = @ItemId";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", tripitem.ItemId, DbType.Int32);
                parameters.Add("ItemName", tripitem.ItemName, DbType.String);
                parameters.Add("ItemDescription", tripitem.ItemDescription, DbType.String);
                parameters.Add("PriceMin", tripitem.PriceMin, DbType.Decimal);
                parameters.Add("PriceMax", tripitem.PriceMax, DbType.Decimal);
                parameters.Add("Quantity", tripitem.Quantity, DbType.Int32);
                parameters.Add("ItemCategory", tripitem.CategoryId, DbType.Int32);
                parameters.Add("UpdateDate", tripitem.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", tripitem.UpdateBy, DbType.String);
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
                var query = "DELETE FROM trip_item WHERE ItemId = @ItemId";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", tripItemId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripItemByTripId(string tripId)
        {
            try
            {
                var query = "DELETE FROM trip_item WHERE TripId = @TripId";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CheckIfItemNameExisted(string itemName)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip_item WHERE LOWER(`ItemName`) = @itemName";
                var parameters = new DynamicParameters();
                parameters.Add("itemName", itemName, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
