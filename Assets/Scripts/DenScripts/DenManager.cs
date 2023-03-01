/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 27/01/2023
/// Purpose : Script for any den related updates/checks
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenManager : MonoBehaviour
{
    List<GameObject> DisplayItems = new List<GameObject>(); //list of items that are displayed in the den

    private void Start()
    {
        if (DisplayItems.Count == 0)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("DisplayItem")) //find all display items in the scene
            {
                DisplayItems.Add(go);//add any found objects to a list
            }
        }
        LoadDen();
    }

    /// <summary>
    /// function for when the den is loaded into
    /// </summary>
    public void LoadDen()
    {
        foreach (GameObject go in DisplayItems) //go though all the display items
        {
            go.GetComponent<DisplayedItem>().UpdateVisibility(); // each item checks if its been found
        }

    }
}
