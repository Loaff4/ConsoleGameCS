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
        Goblin goblin2 = new Goblin(data2);
        

        goblin1.Equip(new Weapon(new ToolData
        {
            OnAttack = new Action<IItemOwner, BaseEntity, BaseTool>((IItemOwner owner, BaseEntity target, BaseTool weapon) =>
            {
                target.GainEffect(new Poison(new EffectData
                {
                    Duration = 1000,
                    Potency = 200
                }, target));
            })
        }));

        goblin1.Attack(goblin2);
        goblin2.TickEffects();
        

    }
}