using System;
using Effects;
using Effects.Data;
using Entities;
using Items;
using Items.Data;
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
                OnAttack = (new Action<BaseEntity>((BaseEntity target) =>
                {
                    target.GainEffect(new Poison(new EffectData {Duration = 3, Potency = 4}, target));
                }))
            }
        ));

        entities[0].Lethality = 100;
        entities[1].Attack(entities[0]);
        entities[0].Attack(entities[1]);
        
        

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