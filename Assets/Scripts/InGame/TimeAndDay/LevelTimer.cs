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

    public float iElapsedTime; //time elapsed since initialized
    [SerializeField]
    Text tTime; //reference to time display ingame
    float fMinutes; //total minutes
    float fSeconds; //total seconds

    // Start is called before the first frame update
    void Start()
    {
        iElapsedTime = 0; //set total elapsed time to 0
    }

    // Update is called once per frame
    void Update()
    {
        iElapsedTime += Time.deltaTime; //increase time

        int fMinutes = Mathf.FloorToInt(iElapsedTime / 60F); //get number of minutes
        int fSeconds = Mathf.FloorToInt(iElapsedTime - fMinutes * 60); //get number of seconds
        
        tTime.text = string.Format("{00:00}:{01:00}", fMinutes, fSeconds); //update text display with time formatted to 00:00
    }

}
