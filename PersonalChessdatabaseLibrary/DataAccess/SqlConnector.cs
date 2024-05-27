using Dapper;
using PersonalChessdatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChessdatabaseLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        public void CreateGame(GameModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString("ChessDB")))
            {
                var p = new DynamicParameters();
                p.Add("@WhitePlayer", model.WhitePlayer);
                p.Add("@BlackPlayer", model.BlackPlayer);
                p.Add("@WhiteFIDE", model.WhiteFide);
                p.Add("@BlackFIDE", model.BlackFide);
                p.Add("@Notation", model.Notation);
                p.Add("@Score", model.Score);
                p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);

                connection.Execute("dbo.spGames_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }

        public GameModel GetGame(int id)
        {
            GameModel output;

            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString("ChessDB")))
            {
                output = connection.Query<GameModel>("dbo.spGames_GetById").FirstOrDefault();
            }

            return output;
        }

        public List<GameModel> GetGame_All()
        {
            List<GameModel> output;

            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString("ChessDB")))
            {
                output = connection.Query<GameModel>("dbo.spGames_GetAll").ToList();
            }

            return output;
        }
    }
}
