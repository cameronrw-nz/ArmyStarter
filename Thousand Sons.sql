DELETE FROM ModelWeapon
DELETE FROM Weapon
DELETE FROM Model
DELETE FROM Unit
DELETE FROM Army
DELETE FROM RosterPosition

DECLARE @ArmyId uniqueidentifier = 'BC6FE9A4-44CA-46BD-B593-228685BE4F1C'

--Units
DECLARE @UnitId1 uniqueidentifier = '05AE033D-96C3-4E29-BC53-E1B12CDA125D'
DECLARE @UnitId2 uniqueidentifier = '39AEC55E-2696-4502-A803-A5A48EEA9DDA'
DECLARE @UnitId3 uniqueidentifier = '05AE033D-96C3-4E29-BC53-E1B12CDA125E'

--Models
DECLARE @AspiringSorcerorId uniqueidentifier = '00178EE3-CC1F-4F84-9503-37E2D8F8BFD4'
DECLARE @RubricMarineId uniqueidentifier = '38AD8160-E6B8-45E2-83DD-EE52331EC234'
DECLARE @TzaangorId uniqueidentifier = 'CE2FC23C-ECC3-4272-851A-5B06BB3D0359'
DECLARE @TwistBrayId uniqueidentifier = '5A9E0835-CE82-4483-9AD9-0EB36B2E72FD'
DECLARE @SorcerorId uniqueidentifier = '5A9E0835-CE82-4483-9AD9-0EB36B2E72FF'

--Weapons
DECLARE @ForceSwordId uniqueidentifier = NEWID();
DECLARE @InfernoBolterId uniqueidentifier = NEWID();
DECLARE @InfernoCombiBolterId uniqueidentifier = NEWID();
DECLARE @TzaangorBladeId uniqueidentifier = NEWID();

INSERT INTO RosterPosition (Type) VALUES ('HQ')
INSERT INTO RosterPosition (Type) VALUES ('Elite')
INSERT INTO RosterPosition (Type) VALUES ('Troop')
INSERT INTO RosterPosition (Type) VALUES ('FastAttack')
INSERT INTO RosterPosition (Type) VALUES ('HeavySupport')
INSERT INTO RosterPosition (Type) VALUES ('Fortification')
INSERT INTO RosterPosition (Type) VALUES ('LordOfWar')

INSERT INTO Army (
	ArmyId,
	Name)
VALUES (
	@ArmyId,
	'Thousand Sons')
	
INSERT INTO Unit (
	ArmyId,
	Cost,
	Name,
	UnitId,
	RosterPositionType)
VALUES (
	@ArmyId,
	0,
	'Terminator Sorceror',
	@UnitId3,
	'HQ')

INSERT INTO Model (
	ModelId,
	UnitId,
	Name,
	PointsValue,
	Movement,
	WeaponSkill,
	BallisticSkill,
	Strength,
	Toughness,
	Wounds,
	Attacks,
	LeaderShip,
	ArmourSave,
	InvulnerableSave,
	DefaultModelsPerUnit,
	MaximumModelsPerUnit)
VALUES (
	@SorcerorId,
	@UnitId3,
	'Terminator Sorceror',
	110,
	5,
	3,
	3,
	4,
	4,
	5,
	3,
	9,
	2,
	5,
	1,
	1)

INSERT INTO Unit (
	ArmyId,
	Cost,
	Name,
	UnitId,
	RosterPositionType)
VALUES (
	@ArmyId,
	1650,
	'Rubric Marines',
	@UnitId1,
	'Troop')

INSERT INTO Model (
	ModelId,
	UnitId,
	Name,
	PointsValue,
	Movement,
	WeaponSkill,
	BallisticSkill,
	Strength,
	Toughness,
	Wounds,
	Attacks,
	LeaderShip,
	ArmourSave,
	InvulnerableSave,
	DefaultModelsPerUnit,
	MaximumModelsPerUnit)
VALUES (
	@AspiringSorcerorId,
	@UnitId1,
	'Aspiring Sorceror',
	16,
	6,
	3,
	3,
	4,
	4,
	1,
	2,
	8,
	3,
	5,
	1,
	1)

INSERT INTO Model (
	ModelId,
	UnitId,
	Name,
	PointsValue,
	Movement,
	WeaponSkill,
	BallisticSkill,
	Strength,
	Toughness,
	Wounds,
	Attacks,
	LeaderShip,
	ArmourSave,
	InvulnerableSave,
	DefaultModelsPerUnit,
	MaximumModelsPerUnit)
VALUES (
	@RubricMarineId,
	@UnitId1,
	'Rubric Marine',
	18,
	5,
	3,
	3,
	4,
	4,
	1,
	1,
	7,
	3,
	5,
	4,
	19)

INSERT INTO Unit (
	ArmyId,
	Cost,
	Name,
	UnitId,
	RosterPositionType)
VALUES (
	@ArmyId,
	1680,
	'Tzaangors',
	@UnitId2,
	'Troop')
	
INSERT INTO Model (
	ModelId,
	UnitId,
	Name,
	PointsValue,
	Movement,
	WeaponSkill,
	BallisticSkill,
	Strength,
	Toughness,
	Wounds,
	Attacks,
	LeaderShip,
	ArmourSave,
	InvulnerableSave,
	DefaultModelsPerUnit,
	MaximumModelsPerUnit)
VALUES (
	@TzaangorId,
	@UnitId2,
	'Tzaangor',
	7,
	6,
	3,
	4,
	4,
	4,
	1,
	1,
	6,
	6,
	5,
	9,
	19)

INSERT INTO Model (
	ModelId,
	UnitId,
	Name,
	PointsValue,
	Movement,
	WeaponSkill,
	BallisticSkill,
	Strength,
	Toughness,
	Wounds,
	Attacks,
	LeaderShip,
	ArmourSave,
	InvulnerableSave,
	DefaultModelsPerUnit,
	MaximumModelsPerUnit)
VALUES (
	@TwistBrayId,
	@UnitId2,
	'Twistbray',
	7,
	6,
	3,
	4,
	4,
	4,
	1,
	2,
	7,
	6,
	5,
	1,
	1)

INSERT INTO Weapon (
	WeaponId,
	AP,
	Attacks,
	Name,
	WeaponType,
	Range,
	Strength)
VALUES (
	@InfernoBolterId,
	2,
	1,
	'Inferno Bolter',
	3,
	24,
	4)

INSERT INTO ModelWeapon (
	WeaponId,
	ModelId,
	CanBeSwapped,
	PointsValue)
VALUES (
	@InfernoBolterId,
	@RubricMarineId,
	1,
	2)

INSERT INTO Weapon (
	WeaponId,
	AP,
	Attacks,
	Name,
	WeaponType,
	Range,
	Strength)
VALUES (
	@InfernoCombiBolterId,
	2,
	2,
	'Inferno Bolter',
	3,
	24,
	4)

INSERT INTO Weapon (
	WeaponId,
	AP,
	Attacks,
	Name,
	WeaponType,
	Range,
	Strength)
VALUES (
	@ForceSwordId,
	3,
	0,
	'Force Sword',
	0,
	0,
	0)

INSERT INTO ModelWeapon (
	WeaponId,
	ModelId,
	CanBeSwapped,
	PointsValue)
VALUES (
	@InfernoCombiBolterId,
	@SorcerorId,
	0,
	3)

INSERT INTO ModelWeapon (
	WeaponId,
	ModelId,
	CanBeSwapped,
	PointsValue)
VALUES (
	@ForceSwordId,
	@SorcerorId,
	0,
	8)

INSERT INTO Weapon (
	WeaponId,
	AP,
	Attacks,
	Name,
	WeaponType,
	Range,
	Strength)
VALUES (
	@TzaangorBladeId,
	1,
	1,
	'Tzaangor Blades',
	0,
	0,
	0)

INSERT INTO ModelWeapon (
	WeaponId,
	ModelId,
	CanBeSwapped,
	PointsValue)
VALUES (
	@TzaangorBladeId,
	@TzaangorId,
	0,
	0)

INSERT INTO ModelWeapon (
	WeaponId,
	ModelId,
	CanBeSwapped,
	PointsValue)
VALUES (
	@TzaangorBladeId,
	@TwistBrayId,
	0,
	0)