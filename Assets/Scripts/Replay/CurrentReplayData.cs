using System.Collections.Generic;

public class CurrentReplayData
{
    public static List<GameChange> ReplayData { get; set; } = new List<GameChange>();
    public static bool isNewHighScore = false;
}
