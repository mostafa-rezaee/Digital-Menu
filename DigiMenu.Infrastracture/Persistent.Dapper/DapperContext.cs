﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        
        public string Products => "[product].Products";

        public string ProductImages => "[product].Images";
    }
}
