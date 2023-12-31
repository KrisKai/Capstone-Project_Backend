﻿using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.Helpers
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection CreateConnection()
        {
            return new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetConnectionString("DEV_PHAT"));
            //return new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetConnectionString("PROD"));
        }
    }
}
