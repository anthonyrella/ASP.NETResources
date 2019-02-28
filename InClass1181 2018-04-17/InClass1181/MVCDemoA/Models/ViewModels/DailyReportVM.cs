using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MVCDemoA.Models;

namespace MVCDemoA.Models.ViewModels
{
    public class DailyReportVM
    {
        public List<Member> NewMembers { get; set; }
        public List<Game> PopularGamesForTheDay { get; set; }
    }
}