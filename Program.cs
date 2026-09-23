using System.Text.Json;
using ConsoleGame.Utilities;
using ConsoleGame.Effects;
using ConsoleGame.Effects.Data;
using ConsoleGame.Entities;
using ConsoleGame.Entities.Data;
using ConsoleGame.Items;
using ConsoleGame.Items.Data;
using ConsoleGame.Items.Interfaces;
using ConsoleGame.Places;
using ConsoleGame.Places.Data;
using ConsoleGame.Places.PointsOfInterest;
using ConsoleGame.Places.PointsOfInterest.Data;
namespace ConsoleGame;

class Program {

    public static Dictionary<int, BaseEntity> entities = new();
    public static void Main(string[] args) {
        EntityData butt = EntityData.Empty;
        string jsonString = JsonSerializer.Serialize(new EntityData
        {
            Health = 100,
            Level = 10,
            Lethality = 10,
            Strength = 100,
            Shield = 55,
            DodgeChance = 6,
            Name = "Jared"
        });
        string jsonString2 = JsonSerializer.Serialize(new EntityData
        {
            Health = 100,
            Level = 10,
            Lethality = 10,
            Strength = 100,
            Shield = 199,
            DodgeChance = 6,
            Name = "d"
        });
        
        EntityData data = JsonUtil.JsonToEntityData(jsonString);
        EntityData data2 = JsonUtil.JsonToEntityData(jsonString2);
        Goblin goblin1 = new Goblin(data);
        Console.WriteLine("Health: " + goblin1.MaxHealth);

        Goblin golbin2 = new Goblin(data2);
        Console.WriteLine("shield: " + golbin2.Shield);

        string damageString = JsonSerializer.Serialize(new DamageData
        {
            DamageAmount = 23232,
            DamageSource = golbin2
        });
        DamageData damageData = JsonUtil.JsonToDamageData(damageString);
        golbin2.OnAttacked(goblin1, damageData, false);
        Console.WriteLine(golbin2.CurrentHealth);
        // Place place = new Place(new PlaceData
        // {
        //     Pois = new List<BasePoi> 
        //     {
        //         new GatheringPoi(new GatheringData
        //         {
        //             GatheredEntities = new BaseEntity[] 
        //             {
        //                 new Goblin(new EntityData
        //                 {
        //                     Level = 5,
        //                     Health = 100,
        //                     DodgeChance = 0,
        //                     Strength = 1,
        //                     Lethality = 0,
        //                     Name = "Runcklo"


        //                 }), 
        //                 new Goblin(new EntityData
        //                 {
        //                     Level = 5,
        //                     Health = 100,
        //                     DodgeChance = 0,
        //                     Strength = 1,
        //                     Lethality = 0,
        //                     Name = "Fumby",
        //                 })
        //             },
        //             DangerLevel = 5,
        //             Name = "'Goblin Gathering'"
        //         })
        //     },
        //     Name = "Goblin Mountain",
        //     EnteringMessage = "Beware the goblins!",
        // });

        // place.OnEnter();

        // BaseEntity entity1 = ((GatheringPoi)place.Pois[0]).GatheredEntites[0];
        // BaseEntity entity2 = ((GatheringPoi)place.Pois[0]).GatheredEntites[1];
        // entity1.Equip(new Weapon(new ToolData
        // {
        //     Value = 100,
        //     Level = entity1.Level,
        //     AttackDamage = 50,
        //     Durability = 50,
        //     CriticalFactor = 20,
        //     Lifesteal = 100,
        //     OnAttack = new Action<IItemOwner, BaseEntity, BaseTool>((IItemOwner owner, BaseEntity target, BaseTool thisWeapon) =>
        //     {
        //         target.GainEffect(new Poison(new EffectData
        //         {
        //             Duration = 1,
        //             Potency = 2
        //         }, target));
        //     }),
        //     Name = "Sword of Poison"


        // }));
        // entity1.Attack(entity2);
        
        // foreach (BaseEntity entity in ((GatheringPoi)place.Pois[0]).GatheredEntites)
        // {

        //     foreach (BaseEffect effect in entity.CurrentEffects)
        //     {
        //         Console.WriteLine($"{entity.Name} has the effect: {effect.Name}");
        //     }
        //     entity.TickEffects();
        //     Console.WriteLine($"{entity.Name} has {entity.CurrentHealth} health");
        // }
    }
}