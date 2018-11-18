
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Kpmg.Models;
using Oracle.ManagedDataAccess.Client;

namespace Kpmg.Services
{
    public class DataLoadService
    {
        string _connectionString;

        public DataLoadService(string connectionString)
        {
            _connectionString = connectionString;

        }

        public async Task<DataSet> Load(string mfid, DateTime navdate){

            var ds = new DataSet();
            using (var con = new OracleConnection(_connectionString)){
                await con.OpenAsync();
                ds.Tables.Add(await LoadDataAsync(QueryProvider.BALANCES,con,"Balances"));
                ds.Tables.Add(await LoadDataAsync(QueryProvider.UNREALWINLOST, con,"GuV"));
            }
            return ds;
        }

        private async Task<DataTable> LoadDataAsync(string query,OracleConnection connection,string tablename ){
            var table = new DataTable();
            using (var com = new OracleCommand( query, connection))
            {
                var res = await com.ExecuteReaderAsync();
                table.Load(res);
                if (!string.IsNullOrEmpty(tablename)){
                    table.TableName = tablename;
                }
                return table;
            }
        }

        public async Task<IEnumerable<Share>> AllMultifondsShares(){
            var shares = new List<Share>();

            using (var cmd = new OracleCommand(QueryProvider.SHARES)){
                var reader = await cmd.ExecuteReaderAsync();
                if(reader.HasRows){
                    while(await reader.ReadAsync()){
                        var share = new Share()
                        {
                            Mfid = reader[0]?.ToString(),
                            Cls = reader[1]?.ToString()
                        };
                        shares.Add(share);
                    }
                }
            }
            return shares;

        }
    }
}
