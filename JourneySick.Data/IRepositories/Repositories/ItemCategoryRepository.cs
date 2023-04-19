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

        public async Task<List<Tblitemcategory>> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemCategoryId)
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

                var query = "SELECT * FROM tblitemCategory WHERE fldItemCategoryId LIKE CONCAT('%', @itemCategoryId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tblitemcategory>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tblitemcategory> GetItemCategoryById(int itemCategoryId)
        {
            try
            {
                var query = "SELECT * FROM tblitemCategory WHERE fldItemCategoryId = @fldItemCategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemCategoryId", itemCategoryId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tblitemcategory>(query, parameters);
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
                var query = "SELECT COUNT(*) FROM tblitemCategory WHERE fldItemCategoryId LIKE CONCAT('%', @itemCategoryId, '%')";

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

        public async Task<int> CreateItemCategory(Tblitemcategory tblitemCategory)
        {
            try
            {
                var query = "INSERT INTO tblitemCategory ("
                    + "         fldItemCategoryId, "
                    + "         fldItemCategoryName, "
                    + "         fldItemCategoryDescription, "
                    + "         fldPriceMin, "
                    + "         fldPriceMax, "
                    + "         fldQuantity, "
                    + "         fldItemCategoryCategory, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldItemCategoryId, "
                    + "         @fldItemCategoryName, "
                    + "         @fldItemCategoryDescription, "
                    + "         @fldPriceMin, "
                    + "         @fldPriceMax, "
                    + "         @fldQuantity, "
                    + "         @fldItemCategoryCategory, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldCategoryId", tblitemCategory.FldCategoryId, DbType.Int32);
                parameters.Add("fldCreateDate", tblitemCategory.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tblitemCategory.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateItemCategory(Tblitemcategory tblitemCategory)
        {
            try
            {
                var query = "UPDATE tblitemCategory SET " +
                    "fldItemCategoryName = @fldItemCategoryName, " +
                    "fldItemCategoryDescription = @fldItemCategoryDescription, " +
                    "fldPriceMin = @fldPriceMin, " +
                    "fldPriceMax = @fldPriceMax, " +
                    "fldQuantity = @fldQuantity, " +
                    "fldItemCategoryCategory = @fldItemCategoryCategory, " +
                    "fldUpdateDate = @fldUpdateDate, " +
                    "fldUpdateBy = @fldUpdateBy " +
                    "WHERE fldItemCategoryId = @fldItemCategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("FldCategoryId", tblitemCategory.FldCategoryId, DbType.Int32);
                parameters.Add("fldUpdateDate ", tblitemCategory.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tblitemCategory.FldUpdateBy, DbType.String);
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
                var query = "DELETE FROM tblitemCategory WHERE fldItemCategoryId = @fldItemCategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemCategoryId", itemCategoryId, DbType.String);
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
