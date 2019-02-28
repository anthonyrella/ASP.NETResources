using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVCDemoB.Models
{
    [MetadataType(typeof(MemberMetaData))]
    public partial class Member
    {
    }

    [MetadataType(typeof(GameMetaData))]
    public partial class Game
    {

       
    }
}