
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Kpmg.Services
{
    public class DataLoadService
    {
        OracleConnection _con;

        public DataLoadService(OracleConnection con)
        {
            _con = con;
        }

        public DataSet Load(string mfid, DateTime navdate){

            var ds = new DataSet();
            using (var com = new OracleCommand("",_con)) {

            }
        }

        private string[] getMultifondsCls(string mfid){

        }
    }
}
