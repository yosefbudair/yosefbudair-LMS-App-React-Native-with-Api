﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badges.Core.Common;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Badges.Infra.Common
{
    public class DbContext : IDbContext
    {

        private DbConnection _connection;
        private readonly IConfiguration _configuration;



        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public DbConnection Connection
        {
            get
            {



                if (_connection == null)
                {
                    _connection = new OracleConnection(_configuration["ConnectionStrings:DefaultConnection"]);

                    _connection.Open();
                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }



                return _connection;
            }


        }




    }
}
