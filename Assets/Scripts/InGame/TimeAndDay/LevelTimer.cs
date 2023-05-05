/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 04/02/2023
/// Purpose :  keep track of time since initialized
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    ExitLevel ExitLevelRef;


    [SerializeField]
    Light lLightSunRising;

    public float iElapsedTime; //time elapsed since initialized
    [SerializeField]
    Text tTime; //reference to time display ingame

    // Start is called before the first frame update
    void Start()
    {
        iElapsedTime = 300; //set timer to start at 5mins
        ExitLevelRef = FindAnyObjectByType<ExitLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        iElapsedTime -= Time.deltaTime; //increase time

        int fMinutes = Mathf.FloorToInt(iElapsedTime / 60F); //get number of minutes
        int fSeconds = Mathf.FloorToInt(iElapsedTime - fMinutes * 60); //get number of seconds
        
        tTime.text = string.Format("{00:00}:{01:00}", fMinutes, fSeconds); //update text display with time formatted to 00:00
        if (lLightSunRising.isActiveAndEnabled)
        {
            //lLightSunRising.intensity = 300 / iElapsedTime;

            float fDecrease = 300 - iElapsedTime;
            float fPercentDecrease = (fDecrease / 300);

            lLightSunRising.intensity = (1 *(fPercentDecrease / 3));
        }



        if (iElapsedTime <= 0)
        {
            ExitLevelRef.Death();
            Debug.Log("Death triggered from time running out, handle seperately");
        }
    }

}
