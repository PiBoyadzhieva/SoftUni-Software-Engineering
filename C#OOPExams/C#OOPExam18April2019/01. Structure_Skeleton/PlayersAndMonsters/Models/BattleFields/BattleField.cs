using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if(attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            //if(attackPlayer is Beginner) - Another Way
            if(attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            int bonushealthAttacker = attackPlayer.CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            int bonushealthEnemy = enemyPlayer.CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            attackPlayer.Health += bonushealthAttacker;
            enemyPlayer.Health += bonushealthEnemy;


            while (true)
            {
                var attackPlayerDamage = attackPlayer.CardRepository
                    .Cards
                    .Sum(x => x.DamagePoints);

                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyPlayerDamage = enemyPlayer.CardRepository
                    .Cards
                    .Sum(x => x.DamagePoints);

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
