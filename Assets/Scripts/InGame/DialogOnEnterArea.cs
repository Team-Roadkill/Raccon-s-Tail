using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogOnEnterArea : MonoBehaviour
{
    [SerializeField] GameObject goDialogBox;
    [SerializeField] Text tDialogText;
    [SerializeField] string newDialog;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(dialogdisplay());
        }
    }

    IEnumerator dialogdisplay()
    {
        goDialogBox.SetActive(true);
        tDialogText.text = newDialog;
        yield return new WaitForSeconds(5);
        goDialogBox.SetActive(false);
    }

}
