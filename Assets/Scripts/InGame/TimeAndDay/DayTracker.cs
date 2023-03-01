using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTracker : MonoBehaviour, IDataPersistence
{

    public int iElapsedDays; //number of days passed
    [SerializeField]
    Text tTotalDays; //days display


    // Start is called before the first frame update
    void Start()
    {
        UpdateDays(); 
    }

    /// <summary>
    /// increase the number of days by 1
    /// </summary>
    public void DayCompleted()
    {
        iElapsedDays++;
    }

    /// <summary>
    /// update day display
    /// </summary>
    public void UpdateDays()
    {
        tTotalDays.text = "Day " + iElapsedDays.ToString(); //update the display day
    }

    /// <summary>
    /// load game data from file
    /// </summary>
    /// <param name="gdData"></param>
    public void LoadData(GameData gdData)
    {
        iElapsedDays = gdData.iDaysPassed;
        UpdateDays();
    }

    /// <summary>
    /// save data to file
    /// </summary>
    /// <param name="gdData"></param>
    public void SaveData(ref GameData gdData)
    {
        gdData.iDaysPassed = iElapsedDays;
    }
}