/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 27/01/2023
/// Purpose : display collectables within the den
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DisplayedItem : MonoBehaviour, IDataPersistence
{
    [Header("ID - Make sure not to duplicate and link to correct collectable")]
    [SerializeField]
    string sLinkedCollectableID; //id of corrisponding in game collectable

    [Header("Collectable Infomation")]
    public string sCollectableName; //name of the collectable 
    public string sCollectableDescription; //description of the collectable - Will be displayed with the item in the den

    bool bHasBeenFound = false;

    void Start()
    {
        UpdateVisibility();
    }

    /// <summary>
    /// hide attached object and collider
    /// </summary>
    public void UpdateVisibility()
    {
        gameObject.GetComponent<Renderer>().enabled = bHasBeenFound; //hide the item once its been collected
        gameObject.GetComponent<Collider>().enabled = bHasBeenFound; //prevent the player from colliding now the items been colected
    }

    /// <summary>
    /// load if corrisponding collectable has been found
    /// </summary>
    /// <param name="gdData"></param>
    public void LoadData(GameData gdData)
    {
        gdData.sbCollectablesFound.TryGetValue(sLinkedCollectableID, out bHasBeenFound); //check save data for if this id has been collected

        if (bHasBeenFound == true) //if it has been collected
        {
            UpdateVisibility(); //update this item
        }
    }

    public void SaveData(ref GameData gdData)
    {
    }

    /// <summary>
    /// show text to display id
    /// </summary>
    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.Label(transform.position, "Item ID: " + sLinkedCollectableID.ToString());
    }
    #endif
}
