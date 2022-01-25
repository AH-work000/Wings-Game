using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeDifficultyController : MonoBehaviour
{
    // GameMode Selections Enum
    public enum GameMode { Easy = 4, Medium = 3, Hard = 1 };

    // Global Singleton Variable: Stores the selected gameMode variable
    public static GameMode selectedGameMode;

}
