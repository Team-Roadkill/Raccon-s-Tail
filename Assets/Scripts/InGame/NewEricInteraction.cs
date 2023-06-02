using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEricInteraction : MonoBehaviour
{
    [SerializeField] GameObject goDialog;
    [SerializeField] Text TextArea;

    bool bIsTimerActive;

    [SerializeField] string sDialog;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(dialogdisplay());
        }
    }

    IEnumerator dialogdisplay()
    {
        if (bIsTimerActive == true)
        {
            yield break;
        }
        bIsTimerActive = true;
        goDialog.SetActive(true);
        TextArea.text = sDialog;
        yield return new WaitForSeconds(3);
        goDialog.SetActive(false);
        bIsTimerActive = false;
    }


}
