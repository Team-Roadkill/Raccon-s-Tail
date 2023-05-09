/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 06/02/2023
/// Purpose : 
/// improvements : traps should inherit from a general trap class
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IDataPersistence
{
    public string sTrapID; //id for this trap
    [ContextMenu("Generate guid for id")] //gives new option on script right click
    private void GenerateGuid() //generate a random ID to use
    {
        sTrapID = System.Guid.NewGuid().ToString(); //sets id to random 32char string
    }

    enum TrapTypes
    {
        Spike,
        WallPortal,
        CeilingPortal,

    }
    [SerializeField]
    TrapTypes TrapType;

    [SerializeField]
    float fDelay;
    [SerializeField]
    float fDuration;

    bool bIsShown = false;
    bool bShouldHideNextRun = false;

    public void Start()
    {
        //UpdateVisibility();
        
        if (bShouldHideNextRun == true)
        {

        }

        this.gameObject.GetComponent<MeshRenderer>().enabled = false;



    }

    /// <summary>
    /// trigger this trap
    /// </summary>
    public void Trigger()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        if (TrapType == TrapTypes.Spike)
        {
            if (gameObject.GetComponent<Spike>() == null)
            {
                Debug.LogError("Trap script present however missing trap type script");
            }
            StartCoroutine(gameObject.GetComponent<Spike>().Activate(fDelay, fDuration)); //start the trap
            bShouldHideNextRun = true; //make sure the trap is removed on progress save
        }
        else if (TrapType == TrapTypes.WallPortal)
        {
            StartCoroutine(gameObject.GetComponent<WallPortal>().Activate(fDelay, fDuration));
            bShouldHideNextRun = true; //make sure the trap is removed on progress save
        }
    }


    /// <summary>
    /// hide attached object and collider
    /// </summary>
    public void UpdateVisibility()
    {
        gameObject.GetComponent<Renderer>().enabled = bIsShown;
        gameObject.GetComponent<Collider>().enabled = bIsShown;
    }

    public void LoadData(GameData gdData)
    {
        gdData.sbTrapsAndTier.TryGetValue(sTrapID, out bIsShown); //check save data for if this id has been collected

        if (bIsShown == true) //if it has been collected
        {
            UpdateVisibility(); //update this item
        }
    }


    public void SaveData(ref GameData gdData)
    {

        if (gdData.sbTrapsAndTier.ContainsKey(sTrapID)) //if already has save data for collectable id
        {
            gdData.sbTrapsAndTier.Remove(sTrapID); //remove id from save
        }


        if (bShouldHideNextRun == true) //should the trap be seen during the next run 
        {
            gdData.sbTrapsAndTier.Add(sTrapID, false); //add new entry for collectable to save data
        }
        else
        {
            gdData.sbTrapsAndTier.Add(sTrapID, true); //add new entry for collectable to save data
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a_cColliderInfo"></param>
    private void OnTriggerEnter(Collider a_cColliderInfo)
    {
        if (a_cColliderInfo.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            Trigger();
        }
    }

    public void Disarm()
    {
        Debug.Log("disarm");
        this.gameObject.SetActive(false);
    }



}
