using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour, IDataPersistence
{
    DialogInteraction diaInterRef;

    public bool bHammerFound = false;

    // Start is called before the first frame update
    void Start()
    {
        diaInterRef = FindAnyObjectByType<DialogInteraction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bHammerFound = true;
            diaInterRef.itemObtained = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            
        }
    }

    public void LoadData(GameData gdData)
    {
        bHammerFound = gdData.bHammerFound;
    }


    public void SaveData(ref GameData gdData)
    {
        gdData.bHammerFound = bHammerFound;
    }

}
