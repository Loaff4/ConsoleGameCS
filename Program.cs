using System;
using Entities;
using Items;
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
                AttackDamage = 15,
                CriticalFactor = 45,
                MaxDurability = 50,
                Level = 1
            }
        ));
        entities[0].lethality = 45;

        entities[0].Attack(entities[1]);
        foreach (KeyValuePair<int, BaseEntity> pair in entities)
        {
            Console.WriteLine($"{pair.Value.Name} has {pair.Value.CurrentHealth} health");
        }


        
    }
}