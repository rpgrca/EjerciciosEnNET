namespace OnlineRpgPlayerToQualifyingStage.Logic;

using System;

public class Kata{
    public static Object PlayerRankUp(int points) =>
        points >= 100
            ? "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up."
            : (Object)false;
}