/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 18/02/2023
/// Purpose :  
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadThisSaveButton : MonoBehaviour
{
    BedroomUI goBedroomUI;

    // Start is called before the first frame update
    void Start()
    {
        goBedroomUI = GameObject.FindObjectOfType<BedroomUI>(); //get the bedroom ui script
    }

    /// <summary>
    /// tell the bedroom ui script that this save has been clicked
    /// </summary>
    public void LoadThisSave()
    {
        goBedroomUI.PlaySaveButton(gameObject);
    }
}
