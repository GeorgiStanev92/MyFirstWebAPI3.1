using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Watsupman";
        public int HitPoints { get; set; } = 100;
        public int Strenght { get; set; } = 60;
        public int Defense { get; set; } = 50;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
        public User User { get; set; }
    }
}
