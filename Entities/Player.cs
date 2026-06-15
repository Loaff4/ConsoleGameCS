using System;
using Entities.Data;
namespace Entities;

class Player : BaseEntity
{
    public Player(EntityData data) : base(data)
    {
        MaxHealth = 120;
        Console.WriteLine("Create a character using a 50 point pool:\n");

        Console.WriteLine("Type the number corresponding to the stat to edit it\n");

        Console.WriteLine("STATS");
        Console.WriteLine("1. Strength");
        Console.WriteLine("2. Quickness");
        Console.WriteLine("3. Shield");
        Console.WriteLine("4. Lethality\n");


        Console.WriteLine("Type 'done' to complete stat assignent\n");
        string? response = Console.ReadLine();
        int points = 50;
        while(response?.ToLower() != "done")
        {
            if (response == null) break;
            if (response.ToLower() == "show")
            {
                ShowStats();
            } 

            if (int.TryParse(response, out int statIndex))
            {
                points = EditStat(statIndex, points);
            }
            
            Console.WriteLine($"You have {points} points left. Type 'show' to view current stats");
            response = Console.ReadLine();
        }
        Console.WriteLine("FINAL STATS");
        ShowStats();
    }

    private void ShowStats()
    {
        Console.WriteLine($"1. (Strength): {Strength}");
        Console.WriteLine($"2. (Quickness): {DodgeChance}");
        Console.WriteLine($"3. (Shield): {Sheild}");
        Console.WriteLine($"4. (Lethality): {Lethality}");
    }

    private int EditStat(int stat, int points)
    {

        Console.Write($"Enter the new value ({points} points left): ");

        string? valueString = Console.ReadLine();
        if (valueString == null) return -1;

        int newValue = int.Parse(valueString);

        int newCap;

        switch (stat)
        {
            case 1:
                newValue = (int)Math.Clamp(newValue, 0, points+Strength);
                newCap = points - (int)(newValue - Strength);
                Strength = newValue;
                break;
            case 2:
                newValue = (int)Math.Clamp(newValue, 0, points+DodgeChance);
                newCap = points - (int)(newValue - DodgeChance);
                DodgeChance = newValue;
                break;
            case 3:
                newValue = (int)Math.Clamp(newValue, 0, points+Sheild);
                newCap = points - (int)(newValue - Sheild);
                Sheild = newValue;
                break;
            case 4:
                newValue = (int)Math.Clamp(newValue, 0, points+Lethality);
                newCap = points - (int)(newValue - Lethality);
                Lethality = newValue;
                break;
            default:
                newCap = points;
                break;                
        }


        return newCap;
    }



}