using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ItemVO>> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId)
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
                parameters.Add("categoryId", categoryId, DbType.Int32);
                var query = "";
                if (categoryId == 0)
                {
                    query = "SELECT * FROM item a INNER JOIN item_category b ON a.CategoryId = b.CategoryId WHERE ItemId LIKE CONCAT('%', @itemId, '%')  LIMIT @firstIndex, @lastIndex";
                }
                else
                {
                    query = "SELECT * FROM item a INNER JOIN item_category b ON a.CategoryId = b.CategoryId WHERE ItemId LIKE CONCAT('%', @itemId, '%') AND a.CategoryId = @categoryId LIMIT @firstIndex, @lastIndex";
                }

                using var connection = CreateConnection();
                return (await connection.QueryAsync<ItemVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Item> GetItemById(int itemId)
        {
            try
            {
                var query = "SELECT * FROM item WHERE ItemId = @ItemId";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", itemId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Item>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Item> GetItemByName(string itemName)
        {
            try
            {
                var query = "SELECT * FROM item WHERE ItemName = @ItemName";

                var parameters = new DynamicParameters();
                parameters.Add("ItemName", itemName, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Item>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

            public async Task<int> CountAllItems(string? itemId, int categoryId)
        {
            try
            {
                var query = "";
                if (categoryId == 0)
                {
                    query = "SELECT COUNT(*) FROM item WHERE ItemId LIKE CONCAT('%', @itemId, '%')";
                }
                else
                {
                    query = "SELECT COUNT(*) FROM item WHERE ItemId AND CategoryId = @categoryId LIKE CONCAT('%', @itemId, '%')";
                }

                itemId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("itemId", itemId, DbType.String);
                parameters.Add("categoryId", categoryId, DbType.Int32);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateItem(Item item)
        {
            try
            {
                var query = "INSERT INTO item ("
                    + "         ItemId, "
                    + "         ItemName, "
                    + "         ItemDescription, "
                    + "         PriceMin, "
                    + "         PriceMax, "
                    + "         Quantity, "
                    + "         CategoryId, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @ItemId, "
                    + "         @ItemName, "
                    + "         @ItemDescription, "
                    + "         @PriceMin, "
                    + "         @PriceMax, "
                    + "         @Quantity, "
                    + "         @CategoryId, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", item.ItemId, DbType.Int32);
                parameters.Add("ItemName", item.ItemName, DbType.String);
                parameters.Add("ItemDescription", item.ItemDescription, DbType.String);
                parameters.Add("PriceMin", item.PriceMin, DbType.Decimal);
                parameters.Add("PriceMax", item.PriceMax, DbType.Decimal);
                parameters.Add("Quantity", item.Quantity, DbType.Int32);
                parameters.Add("CategoryId", item.CategoryId, DbType.Int32);
                parameters.Add("CreateDate", item.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", item.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateItem(Item item)
        {
            try
            {
                var query = "UPDATE item SET " +
                    "ItemName = @ItemName, " +
                    "ItemDescription = @ItemDescription, " +
                    "PriceMin = @PriceMin, " +
                    "PriceMax = @PriceMax, " +
                    "Quantity = @Quantity, " +
                    "CategoryId = @CategoryId, " +
                    "UpdateDate = @UpdateDate, " +
                    "UpdateBy = @UpdateBy " +
                    "WHERE ItemId = @ItemId";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", item.ItemId, DbType.Int32);
                parameters.Add("ItemName", item.ItemName, DbType.String);
                parameters.Add("ItemDescription", item.ItemDescription, DbType.String);
                parameters.Add("PriceMin", item.PriceMin, DbType.Decimal);
                parameters.Add("PriceMax", item.PriceMax, DbType.Decimal);
                parameters.Add("Quantity", item.Quantity, DbType.Int32);
                parameters.Add("CategoryId", item.CategoryId, DbType.Int32);
                parameters.Add("UpdateDate", item.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", item.UpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteItem(int itemId)
        {
            try
            {
                var query = "DELETE FROM item WHERE ItemId = @ItemId";

                var parameters = new DynamicParameters();
                parameters.Add("ItemId", itemId, DbType.String);
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
