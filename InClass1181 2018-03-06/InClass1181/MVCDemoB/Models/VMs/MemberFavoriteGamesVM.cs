using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoB.Models.VMs
{
    public class MemberFavoriteGamesVM
    {
        public Member Member { get; set; }
        public List<FavoriteGame> FavoriteGames { get; set; }

        public MemberFavoriteGamesVM()
        {
            FavoriteGames = new List<FavoriteGame>();
        }
    }


    public class FavoriteGame
    {
        public int Id { get; set; }
        public string GameInfo { get; set; }
        public bool isFavorite { get; set; }

    }

}