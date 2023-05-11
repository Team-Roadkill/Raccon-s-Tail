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
public class EricInteraction : MonoBehaviour, IDataPersistence
{

    //quest options
    [Header("Dialog options")]
    public int iQuestID; //id of the quest this script gives
    public int iHandinQuestID; //id of the quest that needs to be cleared
    [Space(5)]
    [SerializeField] string sQuestGivingDialog; //interact dialog
    [SerializeField] string sTurninDialog; //interact dialog when handing in
    [SerializeField] string sReminderDialog; //reminder of what to do if first quest is active
    [SerializeField] string sQuestObjective; //objective that is displayed in quest tab
    [SerializeField] string sDefaultDialog; //no quests - default 

    [Space(5)]


    //obj ref
    GameObject tDisplayText; //the object that displays the text


    //timer
    [SerializeField] float fTimerLength = 5f; //time dialog is active
    float iTimerDuration = 0; //duration of text display
    
    //script references
    ToolManager ToolManagerRef;
    QuestDisplayManager QuestDisplayManagerRef;

    bool bFirstInteractDone = false;


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
            tDisplayText.transform.parent.gameObject.SetActive(true);
            tDisplayText.SetActive(true);
        }
        else
        {
            tDisplayText.transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider a_cColliderInfo)
    {
        if (a_cColliderInfo.gameObject.tag == "Player") //if player coll
        {
            if (Input.GetKey(KeyCode.E)) //if e pressed
            {
                if (iTimerDuration <= 0)
                {
                    UpDateTextDisplay();
                }
            }
        }
    }

    /// <summary>
    /// update the displayed text
    /// </summary>
    private void UpDateTextDisplay()
    {
        tDisplayText.GetComponent<Text>().text = "?";
        if (QuestDisplayManagerRef.li_isQuests.ContainsKey(iQuestID)) //if this scripts quest is active
        {
            tDisplayText.GetComponent<Text>().text = "Look around for a way into the basement";

            //quest reminder

        }
        else
        {
            if (QuestDisplayManagerRef.li_isQuests.ContainsKey(iHandinQuestID))
            {
                tDisplayText.GetComponent<Text>().text = "Goodjob finding my hammer, heres wand";
                QuestDisplayManagerRef.RemoveQuest(iHandinQuestID); //remove the quest
                bFirstInteractDone = true; //avoid handing in completed before receiving first quest and getting first quest again
                //quest completed

                ToolManagerRef.UnlockWand(); //unlock the watch
            }
            else
            {
                if (bFirstInteractDone == false)
                {
                    tDisplayText.GetComponent<Text>().text = "look for wand, heres watch, goodluck";
                    QuestDisplayManagerRef.AddNewQuest(iQuestID, "quest dialog frog");
                    bFirstInteractDone = true;
                    //giving quest

                    ToolManagerRef.UnlockWatch(); //unlock the watch
                }

            }
        }

        iTimerDuration = fTimerLength; //set timer length
    }


    public void LoadData(GameData gdData)
    {
        bFirstInteractDone = gdData.iEricQuest;
    }


    public void SaveData(ref GameData gdData)
    {
         gdData.iEricQuest = bFirstInteractDone;
    }



}