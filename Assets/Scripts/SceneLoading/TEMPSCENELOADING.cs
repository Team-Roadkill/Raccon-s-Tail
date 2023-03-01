using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEMPSCENELOADING : MonoBehaviour
{
    //functions to load scenes
    //used for buttons as a temp until UI scripts complete

    DataPersistenceManager dpmDataPersistanceManager;

    public void LoadHouse()
    {
        SceneLoader.Load(SceneLoader.Scene.HouseScene);
        dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>();
        dpmDataPersistanceManager.LoadGame();

    }
    
    public void LoadDen()
    {
        dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>();
        if (SceneManager.GetActiveScene().name == "HouseScene")
        {
            dpmDataPersistanceManager.SaveGame();
        }
        SceneLoader.Load(SceneLoader.Scene.DenScene);
    }

    public void LoadDenWithoutSaving()
    {
        SceneLoader.Load(SceneLoader.Scene.DenScene);
    }
}
