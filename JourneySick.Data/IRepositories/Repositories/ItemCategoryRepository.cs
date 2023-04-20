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

                var query = "SELECT * FROM tblitemcategory WHERE fldCategoryId LIKE CONCAT('%', @itemCategoryId, '%')  LIMIT @firstIndex, @lastIndex";

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
                var query = "SELECT * FROM tblitemcategory WHERE fldCategoryId = @fldCategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("fldCategoryId", itemCategoryId, DbType.Int16);
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
                var query = "SELECT COUNT(*) FROM tblitemcategory WHERE fldCategoryId LIKE CONCAT('%', @itemCategoryId, '%')";

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

        public async Task<int> CreateItemCategory(Tblitemcategory tblitemcategory)
        {
            try
            {
                var query = "INSERT INTO tblitemcategory ("
                    + "         fldCategoryName, "
                    + "         fldCategoryDescription, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldCategoryName, "
                    + "         @fldCategoryDescription, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldCategoryName", tblitemcategory.FldCategoryName, DbType.String);
                parameters.Add("fldCategoryDescription", tblitemcategory.FldCategoryDescription, DbType.String);
                parameters.Add("fldCreateDate", tblitemcategory.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tblitemcategory.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateItemCategory(Tblitemcategory tblitemcategory)
        {
            try
            {
                var query = "UPDATE tblitemcategory SET " +
                    "fldCategoryName = @fldCategoryName, " +
                    "fldCategoryDescription = @fldCategoryDescription, " +
                    "fldUpdateDate = @fldUpdateDate, " +
                    "fldUpdateBy = @fldUpdateBy " +
                    "WHERE fldCategoryId = @fldCategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("fldCategoryId", tblitemcategory.FldCategoryId, DbType.Int32);
                parameters.Add("fldCategoryName", tblitemcategory.FldCategoryName, DbType.String);
                parameters.Add("fldCategoryDescription", tblitemcategory.FldCategoryDescription, DbType.String);
                parameters.Add("fldUpdateDate ", tblitemcategory.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tblitemcategory.FldUpdateBy, DbType.String);
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
                var query = "DELETE FROM tblitemcategory WHERE fldCategoryId = @fldCategoryId";

                var parameters = new DynamicParameters();
                parameters.Add("fldCategoryId", itemCategoryId, DbType.String);
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
