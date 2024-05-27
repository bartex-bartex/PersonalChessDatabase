using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChessdatabaseLibrary.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string WhitePlayer { get; set; }
        public string BlackPlayer { get; set; }
        public int WhiteFide { get; set; }
        public int BlackFide { get; set; }
        public string Notation { get; set; }
        public string Score { get; set; }
    }
}
