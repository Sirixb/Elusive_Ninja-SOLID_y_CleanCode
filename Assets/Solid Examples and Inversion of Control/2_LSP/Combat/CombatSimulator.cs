using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class CombatSimulator
    {
        public void Simulate(List<AbstractHero> team1, List<AbstractHero> team2)
        {
            foreach (var hero in team1)
            {
                var opponent = team2[Random.Range(0, team2.Count - 1)];

                //Incumple liskov porque pregunta por los tipos y openclose
                //if (hero is Warrior)
                //{
                //    hero.DoMeleeAttack(opponent);
                //}
                //else if (hero is Archer)
                //{
                //    hero.DoRangeAttack(hero);
                //}
                //else if (hero is Rogue)
                //{
                //    if (Random.Range(1, 100) > 50)
                //    {
                //        hero.DoMeleeAttack(opponent);
                //    }
                //    else
                //    {
                //        hero.DoRangeAttack(opponent);
                //    }
                //}

                //Profe: Si se añade otro heroe no tendre que cambiar esta funcion pero seguimos teniendo metodos vacios en los heroes, se soluciona con Inversion de Control
                if (hero.MeleeAttack && hero.RangeAttack)
                {
                    if (Random.Range(1, 100) > 50)
                    {
                        hero.DoMeleeAttack(opponent);
                    }
                    else
                    {
                        hero.DoRangeAttack(opponent);
                    }
                }
                else if (hero.MeleeAttack)
                {
                    hero.DoMeleeAttack(opponent);
                }
                else if (hero.RangeAttack)
                {
                    hero.DoRangeAttack(hero);
                }
            }
        }
    }
}
