/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 30/01/2023
/// Purpose : script for any collectables/things to pick up
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCollision : MonoBehaviour
{
    ExitLevel ExitLevelRef;

    //may be re looked at when trying to implement multiple scenes within the house to avoid unfindable gameobjects
    //[SerializeField]
    //InventorySO soInventory;

    private void Start()
    {
        ExitLevelRef = FindAnyObjectByType<ExitLevel>();
    }

    /// <summary>
    /// if the player enters a trigger collider process if its something that needs to be picked up
    /// Comment : may want to explore a pickup pop up manager - only allow one message to exist and one item to be picked up at once
    /// </summary>
    /// <param collison info="collision"></param>
    private void OnTriggerEnter(Collider a_cColliderInfo)
    {
        if (a_cColliderInfo.gameObject.tag == "Danger")
        {
            ExitLevelRef.Death();
        }
    }

}
