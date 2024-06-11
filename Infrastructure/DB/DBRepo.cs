using Services.C.Core.Interfaces;
using Services.C.Core.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.C.Infrastructure.DB
{
    public class DBRepo : DBRepoBase, IDBRepo
    {
        #region *** private


        #endregion
        #region *** ctor

        public DBRepo(IOptions<AppSettings> settings, ILoggerRepo logManager) : base(settings, logManager) { }

        #endregion
        #region *** public 

        #endregion
    }
}
