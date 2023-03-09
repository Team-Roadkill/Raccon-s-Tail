using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteraction : MonoBehaviour
{
    GameObject tDisplayText;
    [SerializeField] List<string> a_sAllDialog;

    int iCurrentDisplayedDialogID;

    [SerializeField] float fTimerLength = 5f;
    float iTimerDuration = 0;

    //[SerializeField] QuestManager questManagerRef;
    //temp
    [SerializeField] GameObject quest;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Watch;
    [SerializeField] GameObject Day;
    public bool itemObtained = false;
    ExitLevel exitLevelRef;


    // Start is called before the first frame update
    void Start()
    {
        //exitLevelRef = FindAnyObjectByType<ExitLevel>();
        //Watch = FindAnyObjectByType<Watch>().gameObject;
        //questManagerRef = FindObjectOfType<QuestManager>();
        iCurrentDisplayedDialogID = 0;
        tDisplayText = GameObject.FindGameObjectWithTag("Dialog");
        tDisplayText.SetActive(false);

        quest.SetActive(false);
        Timer.SetActive(false);
        Day.SetActive(false);
        Watch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (iTimerDuration > 0)
        {
            iTimerDuration -= Time.deltaTime;
            tDisplayText.SetActive(true);
        }
        else if (Day.gameObject.activeSelf == false)
        {
            tDisplayText.SetActive(false);
            //if (tDisplayText.gameObject.activeSelf == true)
            //{
            //    UpDateTextDisplay();
            //}
            //else
            //{

            //}
        }
    }

    private void OnTriggerStay(Collider a_cColliderInfo)
    {
        if (a_cColliderInfo.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (tDisplayText.gameObject.activeSelf == false)
                {

                    if (itemObtained == true) //check quest item temp
                    {
                        Timer.SetActive(true);
                        Day.SetActive(true);
                        quest.SetActive(false);
                        tDisplayText.SetActive(true);
                        Watch.SetActive(true);
                        tDisplayText.GetComponent<Text>().text = "Thanks for finding my hammer! Heres your reward 'Watch' it will help you in finding danger - fin";
                        
                        //exitLevelRef.SuccessfulClear();
                    }
                    else if (iTimerDuration <= 0)
                    {
                        iTimerDuration = fTimerLength; //set timer duration to timer length
                        UpDateTextDisplay();
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
            DisplayQuest();
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


    //temp

    public void UpdateQuestText()
    {
        quest.GetComponent<Text>().text = "-Return the hammer to eric";
    }


    public void DisplayQuest()
    {
        quest.SetActive(true);
    }

    public void HideQuest()
    {
        quest.SetActive(false);
    }
}