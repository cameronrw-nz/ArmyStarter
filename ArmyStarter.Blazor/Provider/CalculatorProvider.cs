using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Blazor.Provider
{
    public class CalculatorProvider : ICalculatorProvider
    {
        public decimal GetTotalWoundsResult(AttackingModel attackingModel, DefendingModel defendingModel)
        {
            var toHitResult = GetToHitResult(attackingModel.ToHit);
            var toWoundResult = GetToWoundResult(attackingModel.Strength, defendingModel.Toughness);
            var saveResult = GetSaveResult(attackingModel.AP, defendingModel.ArmourSave ?? 0, defendingModel.InvulnerableSave ?? 0);

            Console.WriteLine($"To Hit: ${toHitResult}, ${attackingModel.ToHit}");

            return toHitResult * toWoundResult * saveResult * attackingModel.Attacks;
        }

        public decimal GetToHitResult(int toHit, int toHitModifier = 0)
        {
            var requiredToHit = toHit + toHitModifier;
            Console.WriteLine($"To Hit: ${requiredToHit} : ${4/6}");

            if (requiredToHit > 6)
            {
                return 0;
            }

            return decimal.Divide(7 - requiredToHit, 6);
        }

        public decimal GetToWoundResult(int strength, int toughness, int toWoundModifier = 0)
        {
            var toWound = 0;
            if (toughness / strength >= 2)
            {
                toWound = 6;
            }
            else if (toughness > strength)
            {
                toWound = 5;
            }
            else if (toughness == strength)
            {
                toWound = 4;
            }
            else if (decimal.Divide(toughness, strength) <= (decimal)0.5)
            {
                toWound = 2;
            }
            else
            {
                toWound = 3;
            }

            toWound += toWoundModifier;

            return decimal.Divide(7 - toWound, 6);
        }

        public decimal GetSaveResult(int ap, int armourSave = 0, int invulnerableSave = 0)
        {
            var saveValue = armourSave + ap;
            if (saveValue > 6)
            {
                if (invulnerableSave == 0)
                {
                    return 1;
                }

                saveValue = invulnerableSave;
            }

            return decimal.Divide(7 - saveValue, 6);
        }
    }
}
