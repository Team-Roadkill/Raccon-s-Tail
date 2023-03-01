/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/01/2023
/// Purpose : Script for updating the progress bar of the loading screen
/////////////////////////////////////////////////////////.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    Image iLoadingProgressImage; //progress bar to update
    
    private void Awake()
    {
        iLoadingProgressImage = transform.GetComponent<Image>(); //get the progress bar image
    }

    private void Update()
    {
        iLoadingProgressImage.fillAmount = SceneLoader.GetLoadingProgress(); //update the bar with the current progress
    }

}
