using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace RLLBot.DAL.Models
{
    [Owned]
    public class Demo
    {
        public int Inflicted { get; set; }
        public int Taken { get; set; }
    }
}
