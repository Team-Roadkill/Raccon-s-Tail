/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 05/02/2023
/// Purpose : script defining a collectable
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempExitHouse : MonoBehaviour
{
    DataPersistenceManager dpmDataPersistanceManager;

    private void Start()
    {
        dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            dpmDataPersistanceManager.SaveGame();
            SceneLoader.Load(SceneLoader.Scene.DenScene);
        }

        if (Input.GetKey(KeyCode.L))
        {
            dpmDataPersistanceManager.LoadGame();
        }
    }
}
