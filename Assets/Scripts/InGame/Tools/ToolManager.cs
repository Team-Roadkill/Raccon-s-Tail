/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 17/02/2023
/// Purpose :  manage tools if unlocked, if equipped and interaction
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] GameObject goWatchObject;
    [SerializeField] GameObject goWandObject;
    [SerializeField] GameObject goGauntletObject;
    [SerializeField] GameObject goHatObject;

    private void Start()
    {
        goWatchObject.SetActive(false);
        goWandObject.SetActive(false);
        goGauntletObject.SetActive(false);
        goHatObject.SetActive(false);
    }



    public void UnlockWatch()
    {
        goWatchObject.SetActive(true);
    }

    public void UnlockWand()
    {
        goWandObject.SetActive(true);
    }

    public void UnlockGauntlet()
    {
        goGauntletObject.SetActive(true);
    }
    public void UnlockHat()
    {
        goHatObject.SetActive(true);
    }

    public void LoadData(GameData gdData)
    {
        foreach (string s in gdData.tools)
        {
            if (s == "Watch")
            {
                UnlockWatch();
            }
            else if (s == "Wand")
            {
                UnlockWand();
            }
            else if (s == "Gauntlet")
            {
                UnlockGauntlet();
            }
            else if (s == "Hat")
            {
                UnlockHat();
            }
        }
    }

    public void SaveData(ref GameData gdData)
    {
        gdData.tools = new string[3];
        if (goWatchObject.activeSelf == true)
        {
            gdData.tools[0] = "Watch";
        }
        else
        {
            gdData.tools[0] = "";
        }

        if (goWatchObject.activeSelf == true)
        {
            gdData.tools[1] = "Wand";
        }
        else
        {
            gdData.tools[1] = "";
        }

        if (goWatchObject.activeSelf == true)
        {
            gdData.tools[2] = "Gauntlet";
        }
        else
        {
            gdData.tools[2] = "";
        }

        if (goWatchObject.activeSelf == true)
        {
            gdData.tools[3] = "Hat";
        }
        else
        {
            gdData.tools[3] = "";
        }
    }
}
