using System;

namespace ArmyStarter.Blazor.Provider
{
    public class CalculatorProvider : ICalculatorProvider
    {
        public decimal GetTotalWoundsResult(AttackingModel attackingModel, DefendingModel defendingModel)
        {
            var toHitResult = (decimal)1;
            if (!attackingModel.IsAutoHitting)
            {
                toHitResult = GetToHitResult(attackingModel.ToHit, attackingModel.IsRerollingHits);
            }
            var toWoundResult = GetToWoundResult(attackingModel.Strength, defendingModel.Toughness);
            var saveResult = GetSaveResult(attackingModel.AP, defendingModel.ArmourSave ?? 0, defendingModel.InvulnerableSave ?? 0);

            return Math.Round(toHitResult * toWoundResult * saveResult * attackingModel.Attacks, 2) * attackingModel.Damage;
        }

        public decimal GetToHitResult(int toHit, bool isRerollingHits, int toHitModifier = 0)
        {
            var requiredToHit = toHit + toHitModifier;

            if (requiredToHit > 6)
            {
                return 0;
            }

            var hitResult = decimal.Divide(7 - requiredToHit, 6);
            if(isRerollingHits)
            {
                hitResult = hitResult + decimal.Divide(5-requiredToHit, 6) * hitResult;
            }

            return hitResult;
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

            return 1 - decimal.Divide(7 - saveValue, 6);
        }
    }
}
