using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEricInteraction : MonoBehaviour
{
    [SerializeField] GameObject goDialog;
    [SerializeField] Text TextArea;

    [SerializeField] float fTimerDuration;
    float fTimer;
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
        goDialog.SetActive(true);
        TextArea.text = sDialog;
        yield return new WaitForSeconds(3);
        goDialog.SetActive(false);
    }


}
