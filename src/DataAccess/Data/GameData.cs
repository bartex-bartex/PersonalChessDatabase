using PersonalChessdatabaseLibrary.DataAccess.DbAccess;
using PersonalChessdatabaseLibrary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChessdatabaseLibrary.DataAccess.Data;
public class GameData : IGameData
{
    private readonly ISqlDataAccess _db;

    public GameData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<GameModel>> GetGames() =>
        _db.LoadData<GameModel, dynamic>("dbo.spGames_GetAll", new { });

    public async Task<GameModel?> GetGame(int id)
    {
        var results = await _db.LoadData<GameModel, dynamic>(
            "dbo.spGames_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public Task InsertGame(GameModel game)
    {
        return _db.SaveData("dbo.spGames_Insert", new
        {
            game.WhitePlayer,
            game.BlackPlayer,
            game.WhiteFide,
            game.BlackFide,
            game.Notation,
            game.Score
        });
    }

    public Task UpdateGame(GameModel game) =>
        _db.SaveData("dbo.spGames_Update", game);

    public Task DeleteGame(int id) =>
        _db.SaveData("dbo.spGames_DeleteById", new { Id = id });
}
