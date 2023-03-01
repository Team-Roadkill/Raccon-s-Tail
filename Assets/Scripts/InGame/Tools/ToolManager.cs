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
    enum Tools { //list of all selectable hand tools
        Empty,
        Watch,
        Wand,
        Hat,
        Gauntlet,
    }

    //defining keys for each tool
    KeyCode kcEmpty = KeyCode.Alpha0;
    KeyCode kcWatch = KeyCode.Alpha1;
    KeyCode kcWand = KeyCode.Alpha2;
    KeyCode kcHat = KeyCode.Alpha3;
    KeyCode kcGauntlet = KeyCode.Alpha4;

    bool bWatchUnlocked = false; //store if the watch in unlocked
    bool bWandUnlocked = false; //store if the wand in unlocked
    bool bGauntletUnlocked = false; //store if the gauntlet in unlocked 
    bool bHatUnlocked = false; //store if the hat in unlocked

    [SerializeField] GameObject goWatch;
    [SerializeField] GameObject goWand;
    [SerializeField] GameObject goGauntlet;
    [SerializeField] GameObject goHat;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //switch equiped tool when key pressed
        if (Input.GetKeyDown(kcEmpty))
        {
            ToolSwitchFuntionality(Tools.Empty);
        }
        else if (Input.GetKeyDown(kcWatch))
        {
            ToolSwitchFuntionality(Tools.Watch);
        }
        else if (Input.GetKeyDown(kcWand))
        {
            ToolSwitchFuntionality(Tools.Wand);
        }
        else if (Input.GetKeyDown(kcHat))
        {
            ToolSwitchFuntionality(Tools.Gauntlet);
        }
        else if (Input.GetKeyDown(kcGauntlet))
        {
            ToolSwitchFuntionality(Tools.Hat);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void ToolSwitchFuntionality(Tools a_tTool)
    {
        //what happens on each tool being equiped
        switch (a_tTool) {
            case Tools.Empty:
                //player holding update to nothing
                //update ui visual to nothing selected
                break;
            case Tools.Watch:
                //player holding update to watch
                //update ui visual
                goWatch.SetActive(true);
                if (Input.GetKeyDown(kcWatch)) //if key is being pressed /has been pressed
                {
                    //player animation manager
                    //play watch interaction animation
                }
                else
                {
                    //dont play animation
                }
                break;
            case Tools.Wand:



                break;
            case Tools.Hat:



                break;
            case Tools.Gauntlet:



                break;

        }
    }

    /// <summary>
    /// load if tools are unlocked
    /// </summary>
    /// <param name="gdData"></param>
    public void LoadData(GameData gdData)
    {
        gdData.sbToolsUnlocked.TryGetValue("Watch", out bWatchUnlocked);
        gdData.sbToolsUnlocked.TryGetValue("Wand", out bWatchUnlocked);
        gdData.sbToolsUnlocked.TryGetValue("Gauntlet", out bWatchUnlocked);
        gdData.sbToolsUnlocked.TryGetValue("Hat", out bWatchUnlocked);
    }

    public void SaveData(ref GameData gdData)
    {

    }
}
