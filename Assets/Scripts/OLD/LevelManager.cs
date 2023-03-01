/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 29/01/2023
/// Purpose : manages the loot within the scene/a level and acts as a inbetween to allowing them to save
/// 
/// OLD
/// may be resued with the use of multiple scenes to make up the house
/// 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour//, IDataPersistence
{
    DataPersistenceManager dpmDataPersistanceManager; //referance to data persistance manager
    
    List<GameObject> goAllCollectables = new List<GameObject>(); //used to store all collectables within the scene

    private void Start()
    {
        //this object properties
        DontDestroyOnLoad(this.gameObject); //ensure object wont be destroyed

        //get references
        dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>(); //find the data persistant manager instance

        //level setup
        //dpmDataPersistanceManager.LoadGame(); //load data from file
    }


    /// <summary>
    /// should be run when new levels are loaded
    /// resets inventory and loads and needed data
    /// </summary>
    //public void LoadLevel()
    //{
    //    //will run everytime a level is loaded into
    //    dpmDataPersistanceManager.LoadGame(); //load data from file

    //    //get in game displays

    //}

}
