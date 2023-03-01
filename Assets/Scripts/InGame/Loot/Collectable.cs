/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 27/01/2023
/// Purpose : script defining a collectable
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Collectable : MonoBehaviour, IDataPersistence
{

    //this id will also be linked to the display items
    //the id should be displayed in editor above item


    [Header("ID - Make sure not to duplicate")]
    public string sID; //unique identifier
    public bool bHasBeenCollected = false; //has the item been collected


    /// <summary>
    /// update that this item has been collected
    /// </summary>
    public void Collected()
    {
        bHasBeenCollected = true; //update the collected state of the object
        gameObject.GetComponent<Renderer>().enabled = false; //hide the item once its been collected
        gameObject.GetComponent<Collider>().enabled = false; //prevent the player from colliding now the items been colected
    }

    public void LoadData(GameData gdData)
    {
        gdData.sbCollectablesFound.TryGetValue(sID, out bHasBeenCollected); //check save data for if this id has been collected

        if (bHasBeenCollected == true) //if it has been collected
        {
            Collected(); //update this item
        }
    }

    public void SaveData(ref GameData gdData)
    {
         if (gdData.sbCollectablesFound.ContainsKey(sID)) //if already has save data for collectable id
         {
             gdData.sbCollectablesFound.Remove(sID); //remove id from save
         }
         gdData.sbCollectablesFound.Add(sID, bHasBeenCollected); //add new entry for collectable to save data
    }

    /// <summary>
    /// show text to display id
    /// </summary>
    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.Label(transform.position, "Item ID: " + sID.ToString());
    }
    #endif
    private void OnTriggerEnter(Collider a_cColliderInfo)
    {
        if (a_cColliderInfo.gameObject.tag == "Player") //if collsion with collectable object
        {
            Collected(); 
            //soInventory.sCollectablesIDs.Add(cCollectableRef.sID); //add this to the list of found collectables //refer to declaration
        }
    }
}
