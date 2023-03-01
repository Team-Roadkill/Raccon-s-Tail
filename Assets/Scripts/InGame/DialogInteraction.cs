/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 25/02/2023
/// Purpose : when attach object collides with player it will attempt to update displayed dialog
/// room for improvement in implementation
/////////////////////////////////////////////////////////
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

    // Start is called before the first frame update
    void Start()
    {
        iCurrentDisplayedDialogID = 0;
        tDisplayText = GameObject.FindGameObjectWithTag("Dialog");
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
                    if (iTimerDuration <= 0)
                    {
                        iTimerDuration = fTimerLength; //set timer duration to timer length
                    }

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
        if (a_sAllDialog.Count != iCurrentDisplayedDialogID)
        {
            tDisplayText.GetComponent<Text>().text = a_sAllDialog[iCurrentDisplayedDialogID]; //update displayed text
            if (a_sAllDialog.Count >= iCurrentDisplayedDialogID) //check if a string exists after the currently used one
            {
                iCurrentDisplayedDialogID = iCurrentDisplayedDialogID + 1;
            }
        }
        else if (a_sAllDialog.Count < iCurrentDisplayedDialogID) //check if current dialog to display has been exceeded
        {
            iCurrentDisplayedDialogID = 0; //start dialog from begining
        }
        
    }
}
