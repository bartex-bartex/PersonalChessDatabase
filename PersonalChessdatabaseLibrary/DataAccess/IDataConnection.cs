using PersonalChessdatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChessdatabaseLibrary.DataAccess
{
    public interface IDataConnection
    {
        List<GameModel> GetGame_All();
        GameModel GetGame(int id);
        void CreateGame(GameModel model);

    }
}
