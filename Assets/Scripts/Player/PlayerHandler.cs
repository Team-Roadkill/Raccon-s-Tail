/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 06/02/2023
/// Purpose : functions for death/run over in game
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    [SerializeField] ExitLevel ExitLevelRef;

    public void PlayerExitLevel()
    {

    }

    /// <summary>
    /// what happens on player death
    /// </summary>
    public void PlayerDeath()
    {
        //note for future - if use inv system then would clear inv

        //drop items / any animations shouls be called here

        Debug.Log("Player Dies");
        ExitLevelRef.Death();

    }

}
