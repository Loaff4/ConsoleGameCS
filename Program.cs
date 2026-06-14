using System;
using Effects;
using Effects.Data;
using Entities;
using Items;
using Items.Data;
using Places;
using Places.Data;
using Places.PointsOfInterest;
using Places.PointsOfInterest.Data;
namespace Main;

class Program {

    public static Dictionary<int, BaseEntity> entities = new();
    public static void Main(string[] args) {
        entities.Add(0, new Goblin(200, 20, "Ginglar"));
        entities.Add(1, new Goblin(200, 20, "Junglok"));
        
        entities[0].Equip(new Weapon(
            new WeaponData
            {
                Name = "Wooden Sword",
                Value = 30,
                AttackDamage = 10,
                CriticalFactor = 0,
                Lifesteal = 20,
                MaxDurability = 50,
                Level = 100,
                OnAttack = (new Action<BaseEntity, Weapon>((BaseEntity target, Weapon thisWeapon) =>
                {
                    target.GainEffect(new Poison(new EffectData {Duration = 3, Potency = 4}, target));
                }))
            }
        ));

        entities[0].Lethality = 100;
        entities[1].Attack(entities[0]);
        entities[0].Attack(entities[1]);
        
        // Place place = new Place(new PlaceData
        // {
        //     Pois = new List<BasePoi> 
        //     {
        //         new GatheringPoi(new GatheringData
        //         {
        //             GatheredEntities = new BaseEntity[] {new Goblin(400, 30, "Punbly"), new Goblin(430, 10, "Clungo")},
        //             DangerLevel = 5,
        //             Name = "'Goblin Gathering'"
        //         })
        //     },
        //     Name = "Goblin Mountain",
        //     EnteringMessage = "Beware the goblins!",
            
            
        // });

        // place.OnEnter();

        // foreach(BasePoi poi in place.Pois)
        // {
        //     if (poi is GatheringPoi gPoi)
        //     {
        //         Console.WriteLine($"{gPoi.Name} has a danger level of {gPoi.DangerLevel}");
        //         foreach (BaseEntity entity in gPoi.GatheredEntites)
        //         {
        //             Console.WriteLine($"{entity.Name} is in {gPoi.Name}");
        //         }
        //     }
        // }

        // place.OnExit();
        // place.OnEnter();
        foreach (KeyValuePair<int, BaseEntity> pair in entities)
        {
            BaseEntity entity = pair.Value;

            foreach (BaseEffect effect in entity.CurrentEffects)
            {
                Console.WriteLine($"{entity.Name} has the effect: {effect.Name}");
            }
            entity.TickEffects();
            Console.WriteLine($"{pair.Value.Name} has {pair.Value.CurrentHealth} health");
        }


        
    }
}