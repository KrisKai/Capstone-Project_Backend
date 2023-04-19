using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
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

        public async Task<List<Tblitem>> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId)
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

                var query = "SELECT * FROM tblitem WHERE fldItemId LIKE CONCAT('%', @itemId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tblitem>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tblitem> GetItemById(int itemId)
        {
            try
            {
                var query = "SELECT * FROM tblitem WHERE fldItemId = @fldItemId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", itemId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tblitem>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllItems(string? itemId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tblitem WHERE fldItemId LIKE CONCAT('%', @itemId, '%')";

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

        public async Task<int> CreateItem(Tblitem tblitem)
        {
            try
            {
                var query = "INSERT INTO tblitem ("
                    + "         fldItemId, "
                    + "         fldItemName, "
                    + "         fldItemDescription, "
                    + "         fldPriceMin, "
                    + "         fldPriceMax, "
                    + "         fldQuantity, "
                    + "         fldItemCategory, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldItemId, "
                    + "         @fldItemName, "
                    + "         @fldItemDescription, "
                    + "         @fldPriceMin, "
                    + "         @fldPriceMax, "
                    + "         @fldQuantity, "
                    + "         @fldItemCategory, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", tblitem.FldItemId, DbType.Int32);
                parameters.Add("fldItemName", tblitem.FldItemName, DbType.String);
                parameters.Add("fldItemDescription", tblitem.FldItemDescription, DbType.String);
                parameters.Add("fldPriceMin", tblitem.FldPriceMin, DbType.Decimal);
                parameters.Add("fldPriceMax", tblitem.FldPriceMax, DbType.Decimal);
                parameters.Add("fldQuantity", tblitem.FldPriceMax, DbType.Int32);
                parameters.Add("fldCategoryId", tblitem.FldCategoryId, DbType.Int32);
                parameters.Add("fldCreateDate", tblitem.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tblitem.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateItem(Tblitem tblitem)
        {
            try
            {
                var query = "UPDATE tblitem SET " +
                    "fldItemName = @fldItemName, " +
                    "fldItemDescription = @fldItemDescription, " +
                    "fldPriceMin = @fldPriceMin, " +
                    "fldPriceMax = @fldPriceMax, " +
                    "fldQuantity = @fldQuantity, " +
                    "fldItemCategory = @fldItemCategory, " +
                    "fldUpdateDate = @fldUpdateDate, " +
                    "fldUpdateBy = @fldUpdateBy " +
                    "WHERE fldItemId = @fldItemId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", tblitem.FldItemId, DbType.Int32);
                parameters.Add("fldItemName", tblitem.FldItemName, DbType.String);
                parameters.Add("fldItemDescription", tblitem.FldItemDescription, DbType.String);
                parameters.Add("fldPriceMin", tblitem.FldPriceMin, DbType.Decimal);
                parameters.Add("fldPriceMax", tblitem.FldPriceMax, DbType.Decimal);
                parameters.Add("FldCategoryId", tblitem.FldCategoryId, DbType.Int32);
                parameters.Add("fldUpdateDate ", tblitem.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tblitem.FldUpdateBy, DbType.String);
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
                var query = "DELETE FROM tblitem WHERE fldItemId = @fldItemId";

                var parameters = new DynamicParameters();
                parameters.Add("fldItemId", itemId, DbType.String);
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
