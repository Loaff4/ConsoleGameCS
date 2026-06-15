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
                            Name = "Runcklo"


                        }), 
                        new Goblin(new EntityData
                        {
                            Level = 5,
                            Health = 100,
                            DodgeChance = 0,
                            Strength = 1,
                            Lethality = 0,
                            Name = "Fumby",
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
                target.GainEffect(new Poison(new EffectData
                {
                    Duration = 1,
                    Potency = 2
                }, target));
            }),
            Name = "Sword of Poison"


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