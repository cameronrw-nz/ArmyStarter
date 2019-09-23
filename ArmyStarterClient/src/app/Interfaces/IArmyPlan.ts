import { IArmy } from "./IArmy";

export interface IArmyPlan {
  army: IArmy;
  description?: string;
  name?: string;
  pointsLimit?: number;
  planArmyId?: string;
}
