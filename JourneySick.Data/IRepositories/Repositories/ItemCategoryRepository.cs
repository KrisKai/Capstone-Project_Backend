using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class ItemCategoryRepository : BaseRepository, IItemCategoryRepository
    {
        public ItemCategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ItemCategory>> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemCategoryId)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                itemCategoryId ??= "";
                parameters.Add("itemCategoryId", itemCategoryId, DbType.String);

                var query = "SELECT * FROM item_category WHERE CategoryId LIKE CONCAT('%', @itemCategoryId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<ItemCategory>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ItemCategory> GetItemCategoryById(int itemCategoryId)
        {
            try
            {
                var query = "SELECT * FROM item_category WHERE CategoryId = @CategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("CategoryId", itemCategoryId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<ItemCategory>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllItemCategorys(string? itemCategoryId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM item_category WHERE CategoryId LIKE CONCAT('%', @itemCategoryId, '%')";

                itemCategoryId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("itemCategoryId", itemCategoryId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateItemCategory(ItemCategory itemcategory)
        {
            try
            {
                var query = "INSERT INTO item_category ("
                    + "         CategoryName, "
                    + "         CategoryDescription, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @CategoryName, "
                    + "         @CategoryDescription, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("CategoryName", itemcategory.CategoryName, DbType.String);
                parameters.Add("CategoryDescription", itemcategory.CategoryDescription, DbType.String);
                parameters.Add("CreateDate", itemcategory.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", itemcategory.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateItemCategory(ItemCategory itemcategory)
        {
            try
            {
                var query = "UPDATE item_category SET " +
                    "CategoryName = @CategoryName, " +
                    "CategoryDescription = @CategoryDescription, " +
                    "UpdateDate = @UpdateDate, " +
                    "UpdateBy = @UpdateBy " +
                    "WHERE CategoryId = @CategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("CategoryId", itemcategory.CategoryId, DbType.Int32);
                parameters.Add("CategoryName", itemcategory.CategoryName, DbType.String);
                parameters.Add("CategoryDescription", itemcategory.CategoryDescription, DbType.String);
                parameters.Add("UpdateDate", itemcategory.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", itemcategory.UpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteItemCategory(int itemCategoryId)
        {
            try
            {
                var query = "DELETE FROM item_category WHERE CategoryId = @CategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("CategoryId", itemCategoryId, DbType.String);
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
