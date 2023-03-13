/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 10/03/2023 ~
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// should call dialog script which would manage displaying text on screen
/// </summary>
public class EricInteraction : MonoBehaviour
{
    [Header("Dialog options")]
    [SerializeField] List<string> a_sAllDialog; //list of dialog text pop ups
    [SerializeField] float fTimerLength = 5f; //time dialog is active
    public int iHammerQuestID = 1; //quest id
    public int iHammerHandinQuestID = 2; //quest id

    public bool itemObtained = false; //if quest item has been obtained

    GameObject tDisplayText; //dialog text field
    int iCurrentDisplayedDialogID = 0; //id of current displayed text
    float iTimerDuration = 0; //duration of text display
    
    //script references
    ToolManager ToolManagerRef;
    QuestDisplayManager QuestDisplayManagerRef;


    //should have
    //dialog pop up/s
    //quest id 1
    //quest promt 1
    //quest id 2
    //quest promt 2



    // Start is called before the first frame update
    void Start()
    {
        ToolManagerRef = FindAnyObjectByType<ToolManager>();
        QuestDisplayManagerRef = FindAnyObjectByType<QuestDisplayManager>();
        tDisplayText = GameObject.FindGameObjectWithTag("DialogField");
        tDisplayText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (iTimerDuration > 0)
        {
            iTimerDuration -= Time.deltaTime;
            tDisplayText.SetActive(true);
        }
        else
        {
            tDisplayText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider a_cColliderInfo)
    {
        if (a_cColliderInfo.gameObject.tag == "Player") //if player coll
        {
            if (Input.GetKey(KeyCode.E)) //if e pressed
            {
                if (tDisplayText.gameObject.activeSelf == false) //if no current dialog displayed
                {
                    if (itemObtained == true) //check quest item temp
                    {
                        tDisplayText.GetComponent<Text>().text = "Thanks for finding my hammer! Heres your reward 'Watch' it will help you in finding danger - fin";
                        ToolManagerRef.UnlockWatch(); //unlock the watch
                        QuestDisplayManagerRef.RemoveQuest(iHammerHandinQuestID); //remove the quest 
                    }
                    else if (iTimerDuration <= 0)
                    {
                        iTimerDuration = fTimerLength; //set timer duration to timer length
                        UpDateTextDisplay(); //update dialog display
                    }
                }
            }
        }
    }

    /// <summary>
    /// update the displayed text
    /// </summary>
    private void UpDateTextDisplay()
    {
        if (iCurrentDisplayedDialogID == (a_sAllDialog.Count - 1))
        {
            QuestDisplayManagerRef.AddNewQuest(iHammerQuestID, "Find eric's hammer");
        }

        if (a_sAllDialog.Count != iCurrentDisplayedDialogID)
        {
            tDisplayText.GetComponent<Text>().text = a_sAllDialog[iCurrentDisplayedDialogID]; //update displayed text
            if (a_sAllDialog.Count >= iCurrentDisplayedDialogID) //check if a string exists after the currently used one
            {
                iCurrentDisplayedDialogID = iCurrentDisplayedDialogID + 1;
            }
        }
        else if (a_sAllDialog.Count <= iCurrentDisplayedDialogID) //check if current dialog to display has been exceeded
        {
            iCurrentDisplayedDialogID = 0; //start dialog from begining
        }
    }

    public void HammerFound()
    {
        itemObtained = true;
        QuestDisplayManagerRef.RemoveQuest(iHammerQuestID);
        QuestDisplayManagerRef.AddNewQuest(iHammerHandinQuestID, "Return erics hammer");

    }

}