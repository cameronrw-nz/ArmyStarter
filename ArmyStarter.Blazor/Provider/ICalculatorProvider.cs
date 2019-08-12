using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Blazor.Provider
{
    public interface ICalculatorProvider
    {
        decimal GetTotalWoundsResult(AttackingModel attackingModel, DefendingModel defendingModel);
    }
}
