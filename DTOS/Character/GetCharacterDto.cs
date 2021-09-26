using dotnet_rpg.DTOS.Skill;
using dotnet_rpg.DTOS.Weapon;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.DTOS.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Watsupman";
        public int HitPoints { get; set; } = 100;
        public int Strenght { get; set; } = 60;
        public int Defense { get; set; } = 50;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skills { get; set; }
    }
}
