
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameOnStart : MonoBehaviour
{
    DataPersistenceManager dpmDataPersistanceManager; //referance to data persistance manager

    // Start is called before the first frame update
    void Start()
    {
        dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>(); //find the data persistant manager instance
        dpmDataPersistanceManager.LoadGame();
        
    }

}
