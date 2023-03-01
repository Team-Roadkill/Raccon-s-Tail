/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 29/01/2023
/// Purpose : interface between other scrips and saving
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    //functions needed within data persistant scripts

    void LoadData(GameData gdData); 

    void SaveData(ref GameData gdData);
}
