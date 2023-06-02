/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 02/03/2023
/// Purpose : functions for death/run over UI
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour, IDataPersistence
{
    DataPersistenceManager dpmDataPersistanceManager; //dpm ref 

    //ui referances
    [SerializeField] GameObject goInGameUI;
    [SerializeField] GameObject goSuccessfulClearUI;
    [SerializeField] GameObject goFailedClearUI;

    private int iDaysCleared;


    private void Start()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// script to show on successful run
    /// shows successful clear ui
    /// </summary>
    public void SuccessfulClear()
    {
        goSuccessfulClearUI.SetActive(true); //show success ui  

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    /// <summary>
    /// script to run on death
    /// shows failed run ui
    /// </summary>
    public void Death()
    {
        goFailedClearUI.SetActive(true); //show failed ui
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    //buttons


    /// <summary>
    /// continue button for the successful run ui
    /// </summary>
    public void ContinueSucessButton()
    {
        Application.Quit();
    }

    /// <summary>
    /// continue button for the failed run ui
    /// </summary>
    public void ContinueFailButton()
    {
        Time.timeScale = 1;
        SceneLoader.Load(SceneLoader.Scene.HouseScene); //load den
    }


    public void LoadData(GameData gdData)
    {
        iDaysCleared = gdData.iDaysPassed + 1;
    }

    public void SaveData(ref GameData gdData)
    {
        gdData.iDaysPassed = iDaysCleared;
    }
}