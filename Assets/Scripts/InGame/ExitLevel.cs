/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 02/03/2023
/// Purpose : functions for death/run over UI
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    DataPersistenceManager dpmDataPersistanceManager; //dpm ref 

    //ui referances
    [SerializeField] GameObject goInGameUI;
    [SerializeField] GameObject goSuccessfulClearUI;
    [SerializeField] GameObject goFailedClearUI;

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
        goInGameUI.SetActive(false); //hide all other ui
        goSuccessfulClearUI.SetActive(true); //show success ui  

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }

    /// <summary>
    /// script to run on death
    /// shows failed run ui
    /// </summary>
    public void Death()
    {
        goInGameUI.SetActive(false); //hide all other ui    
        goFailedClearUI.SetActive(true); //show failed ui

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// continue button for the successful run ui
    /// </summary>
    public void ContinueSucessButton()
    {
        //dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>(); //get dpm
        //dpmDataPersistanceManager.SaveGame(); //save progress
        //SceneLoader.Load(SceneLoader.Scene.DenScene); //load den


        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    /// <summary>
    /// continue button for the failed run ui
    /// </summary>
    public void ContinueFailButton()
    {
        //SceneLoader.Load(SceneLoader.Scene.DenScene); //load den


        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
