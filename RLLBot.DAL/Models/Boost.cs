using Microsoft.EntityFrameworkCore;

namespace RLLBot.DAL.Models;

[Owned]
public class Boost
{
    public int Bpm { get; set; }
    public double Bcpm { get; set; }
    public double AvgAmount { get; set; }
    public int AmountCollected { get; set; }
    public int AmountStolen { get; set; }
    public int AmountCollectedBig { get; set; }
    public int AmountStolenBig { get; set; }
    public int AmountCollectedSmall { get; set; }
    public int AmountStolenSmall { get; set; }
    public int CountCollectedBig { get; set; }
    public int CountStolenBig { get; set; }
    public int CountCollectedSmall { get; set; }
    public int CountStolenSmall { get; set; }
    public int AmountOverfill { get; set; }
    public int AmountOverfillStolen { get; set; }
    public int AmountUsedWhileSupersonic { get; set; }
    public double TimeZeroBoost { get; set; }
    public double PercentZeroBoost { get; set; }
    public double TimeFullBoost { get; set; }
    public double PercentFullBoost { get; set; }
    public double TimeBoost025 { get; set; }
    public double TimeBoost2550 { get; set; }
    public double TimeBoost5075 { get; set; }
    public double TimeBoost75100 { get; set; }
    public double PercentBoost025 { get; set; }
    public double PercentBoost2550 { get; set; }
    public double PercentBoost5075 { get; set; }
    public double PercentBoost75100 { get; set; }
}