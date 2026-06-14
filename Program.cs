using Effects;
using Effects.Data;
using Entities;
using Entities.Data;
using Items;
using Items.Data;
using Items.Interfaces;
using Places;
using Places.Data;
using Places.PointsOfInterest;
using Places.PointsOfInterest.Data;
namespace Main;

class Program {

    public static Dictionary<int, BaseEntity> entities = new();
    public static void Main(string[] args) {
        // entities.Add(0, new Goblin(200, 20, "Ginglar"));
        // entities.Add(1, new Goblin(200, 20, "Junglok"));
        
        // entities[0].Equip(new Weapon(
        //     new ToolData
        //     {
        //         Name = "Wooden Sword",
        //         Value = 30,
        //         AttackDamage = 10,
        //         CriticalFactor = 0,
        //         Lifesteal = 20,
        //         MaxDurability = 50,
        //         Level = 100,
        //         OnUse = (new Action<BaseEntity, BaseTool>((BaseEntity target, BaseTool thisWeapon) =>
        //         {
        //             target.GainEffect(new Poison(new EffectData {Duration = 3, Potency = 4}, target));
        //         }))
        //     }
        // ));

        // entities[0].Lethality = 100;
        // entities[1].Attack(entities[0]);
        // entities[0].Attack(entities[1]);
        
        Place place = new Place(new PlaceData
        {
            Pois = new List<BasePoi> 
            {
                new GatheringPoi(new GatheringData
                {
                    GatheredEntities = new BaseEntity[] 
                    {
                        new Goblin(new EntityData
                        {
                            Level = 5,
                            Health = 100,
                            DodgeChance = 0,
                            Strength = 1,
                            Lethality = 0,
                            Name = "Ass Farter"


                        }), 
                        new Goblin(new EntityData
                        {
                            Level = 5,
                            Health = 100,
                            DodgeChance = 0,
                            Strength = 1,
                            Lethality = 0,
                            Name = "FUCKING BITCH",
                        })
                    },
                    DangerLevel = 5,
                    Name = "'Goblin Gathering'"
                })
            },
            Name = "Goblin Mountain",
            EnteringMessage = "Beware the goblins!",
        });

        place.OnEnter();

        BaseEntity entity1 = ((GatheringPoi)place.Pois[0]).GatheredEntites[0];
        BaseEntity entity2 = ((GatheringPoi)place.Pois[0]).GatheredEntites[1];
        entity1.Equip(new Weapon(new ToolData
        {
            Value = 100,
            Level = entity1.Level,
            AttackDamage = 50,
            Durability = 50,
            CriticalFactor = 20,
            Lifesteal = 100,
            OnAttack = new Action<IItemOwner, BaseEntity, BaseTool>((IItemOwner owner, BaseEntity target, BaseTool thisWeapon) =>
            {
                target.TakeDamage(new DamageData
                {
                    DamageAmount = 5000,
                    DamageSource = owner
                });
            }),
            Name = "Sword of Wood"


        }));
        entity1.Attack(entity2);
        
        foreach (BaseEntity entity in ((GatheringPoi)place.Pois[0]).GatheredEntites)
        {

            foreach (BaseEffect effect in entity.CurrentEffects)
            {
                Console.WriteLine($"{entity.Name} has the effect: {effect.Name}");
            }
            entity.TickEffects();
            Console.WriteLine($"{entity.Name} has {entity.CurrentHealth} health");
        }


        
    }
}