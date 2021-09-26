using dotnet_rpg.DTOS.Character;
using dotnet_rpg.DTOS.CharacterSkill;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}
