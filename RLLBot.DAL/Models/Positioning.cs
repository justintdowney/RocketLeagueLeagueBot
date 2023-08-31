using Microsoft.EntityFrameworkCore;

namespace RLLBot.DAL.Models;

[Owned]
public class Positioning
{
    public int AvgDistanceToBall { get; set; }
    public int AvgDistanceToBallPossession { get; set; }
    public int AvgDistanceToBallNoPossession { get; set; }
    public int AvgDistanceToMates { get; set; }
    public double TimeDefensiveThird { get; set; }
    public double TimeNeutralThird { get; set; }
    public double TimeOffensiveThird { get; set; }
    public double TimeDefensiveHalf { get; set; }
    public double TimeOffensiveHalf { get; set; }
    public double TimeBehindBall { get; set; }
    public double TimeInFrontBall { get; set; }
    public double TimeMostBack { get; set; }
    public double TimeMostForward { get; set; }
    public int GoalsAgainstWhileLastDefender { get; set; }
    public double TimeClosestToBall { get; set; }
    public double TimeFarthestFromBall { get; set; }
    public double PercentDefensiveThird { get; set; }
    public double PercentOffensiveThird { get; set; }
    public double PercentNeutralThird { get; set; }
    public double PercentDefensiveHalf { get; set; }
    public double PercentOffensiveHalf { get; set; }
    public double PercentBehindBall { get; set; }
    public double PercentInFrontBall { get; set; }
    public double PercentMostBack { get; set; }
    public double PercentMostForward { get; set; }
    public double PercentClosestToBall { get; set; }
    public double PercentFarthestFromBall { get; set; }
}  