export interface IArmy {
  armyId: string;
  availableUnits?: IUnit[];
  name: string;
}

export interface IUnit {
  cost: number;
  link?: string;
  models?: IModel[];
  name: string;
  rosterPosition: RosterPosition;
  unitId: string;
}

export enum RosterPosition {
  HQ,
  Elite,
  Troop,
  FastAttack,
  HeavySupport,
  Fortification,
  LordOfWar
}

export interface IModel {
  modelId: string;
  name: string;
  pointsValue: number;
  movement?: number;
  weaponSkill?: number;
  ballisticSkill?: number;
  strength: number;
  toughness: number;
  wounds: number;
  attacks: number;
  leaderShip: number;
  armourSave: number;
  invulnerableSave?: number;
  feelNoPainSave?: number;
  defaultModelsPerUnit: number;
  maximumModelsPerUnit: number;
  weapons: IModelWeapon[];
}

export interface IModelWeapon {
  canBeSwapped: boolean;
  modelId: string;
  pointsValue?: number;
  weapon: IWeapon;
  weaponId: string;
}

export interface IWeapon {
  name: string;
  range: number;
  strength: number;
  ap: number;
  attacks: number;
  weaponId: string;
  weaponType: WeaponType;
}

export enum WeaponType {
  Melee,
  Pistol,
  Assault,
  RapidFire,
  Heavy,
  Macro
}
