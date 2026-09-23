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
        EntityData butt = EntityData.empty;
        string jsonString = JsonSerializer.Serialize(butt);
        
        EntityData data = JsonUtil.JsonToEntityData(jsonString);
        Goblin player = new Goblin(data);
        Console.WriteLine("Health: " + player.MaxHealth);
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