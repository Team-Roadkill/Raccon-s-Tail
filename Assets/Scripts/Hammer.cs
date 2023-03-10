using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour//, DataPersistenceManager
{
    DialogInteraction diaInterRef;

    // Start is called before the first frame update
    void Start()
    {
        diaInterRef = FindAnyObjectByType<DialogInteraction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            diaInterRef.UpdateQuestText();
            diaInterRef.itemObtained = true;
            gameObject.SetActive(false);
        }
    }
}
