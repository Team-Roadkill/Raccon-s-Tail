/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 03/05/2023
/// Purpose :
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrackingManager : MonoBehaviour, IDataPersistence
{






    // Start is called before the first frame update
    void Start()
    {
        //find all trap tracking in scene


    }


    public void LoadData(GameData gdData)
    {
        //find traps in scene with saved ids
        //enable all

        //clear saved ids
    }

    public void SaveData(ref GameData gdData)
    {

        //get trap ids with highest value
        //also get traps that are already enabled


        //save them to game data

    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
