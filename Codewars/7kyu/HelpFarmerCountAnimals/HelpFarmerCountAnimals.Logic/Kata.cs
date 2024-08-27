namespace HelpFarmerCountAnimals.Logic;

using System.Collections.Generic;

public class Kata{
    public static Dictionary<string, int> get_animals_count(int legs_number, int heads_number, int horns_number){
        var cows = horns_number / 2;
        legs_number -= cows * 4;
        heads_number -= cows;

        var rabbits = legs_number / 2 - heads_number;
        var chickens = heads_number - rabbits;

        return new Dictionary<string, int> {
            {"rabbits", rabbits},
            {"chickens", chickens},
            {"cows", cows}
        };
    }
}