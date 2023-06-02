using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPlayHeyOverHere : MonoBehaviour
{
    [SerializeField] GameObject goDialogBox;
    [SerializeField] Text tDialogText;
    [SerializeField] string sStartingDialog;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(dialogdisplay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator dialogdisplay()
    {
        yield return new WaitForSeconds(1);
        goDialogBox.SetActive(true);
        tDialogText.text = sStartingDialog;
        yield return new WaitForSeconds(4);
        goDialogBox.SetActive(false);
    }


}
