namespace ArmyStarter.Models
{
    public static class Constants
    {
        public const string HostUrl = "http://localhost:90/";

        public const string BaseUrl = "api/";

        public const string RootUrl = HostUrl+BaseUrl;

        public const string ArmiesRoute = "armies";

        public const string ArmiesController = RootUrl + ArmiesRoute;

        public const string PlanUnitsRoute = "armyUnits";

        public const string ArmyUnitsController = RootUrl + PlanUnitsRoute;

        public const string PlanArmyRoute = "armyPlan";

        public const string PlanArmiesController = RootUrl + PlanArmyRoute;
    }
}
