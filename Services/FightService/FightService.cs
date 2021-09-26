using dotnet_rpg.Data;
using dotnet_rpg.DTOS.Fight;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _context;

        public FightService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
        {
            ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();
            try
            {
                Character attacker = await _context.Characters
                    .Include(a => a.Weapon)
                    .FirstOrDefaultAsync(a => a.Id == request.AttackerId);
                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(o => o.Id == request.OpponentId);

                // calculating damage done with random function and calculating if the damage is enough to defeat opponent
                int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strenght));
                damage -= new Random().Next(opponent.Defense);
                if (damage > 0)
                {
                    opponent.HitPoints -= damage;
                }
                if (opponent.HitPoints <= 0)
                {
                    response.Message = $"{opponent.Name} has been defeated by {attacker.Name}!";
                }
                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();
                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHP = attacker.HitPoints,
                    Opponent = opponent.Name,
                    OpponentHP = opponent.HitPoints,
                    Damage = damage
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
