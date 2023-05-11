/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 29/01/2023
/// Purpose : game data that will be saved to file
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins; //number of coins collected
    public int iDaysPassed; //current day
    public SerializableDictionary<string, bool> sbCollectablesFound; //collectables collected // ID, collected status
    public SerializableDictionary<string, bool> sbTrapsAndTier; //traps active // ID, trap tier - 0 = none
    public SerializableDictionary<int, string> isActiveQuests; //tools unlocked // Tool, unlocked
    public bool bHammerFound;
    public string[] tools;
    public bool iEricQuest; //tools unlocked // Tool, unlocked

    /// <summary>
    /// constructor for the default values that the game will start with
    /// </summary>
    public GameData()
    {
        this.coins = 0;
        this.iDaysPassed = 0;
        sbCollectablesFound = new SerializableDictionary<string, bool>();
        sbTrapsAndTier = new SerializableDictionary<string, bool>();
        isActiveQuests = new SerializableDictionary<int, string>();
        tools = new string[3];
        bHammerFound = false;
        iEricQuest = false;
    }

}
