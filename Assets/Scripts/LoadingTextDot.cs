/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 17/05/2023
/// Purpose :  change loading text dots
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextDot : MonoBehaviour
{
    Text tLoadingText;

    float fTimer;
    float fTimerStart = 0.5f;
    int iStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        tLoadingText = gameObject.GetComponent<Text>();
        fTimer = fTimerStart;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease timer
        fTimer -= Time.deltaTime;

        //increment stage
        if (fTimer <= 0)
        {
            fTimer = fTimerStart;
            if (iStage == 3)
            {
                iStage = 0;
            }
            else
            {
                iStage++;
            }
        }
        //change loading text depending on stage
        if (iStage == 0)
        {
            tLoadingText.text = "Loading";
        }
        else if (iStage == 1)
        {
            tLoadingText.text = "Loading.";
        }
        else if (iStage == 2)
        {
            tLoadingText.text = "Loading..";
        }
        else if (iStage == 3)
        {
            tLoadingText.text = "Loading...";
        }
    }
}
