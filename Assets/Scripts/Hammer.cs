/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 10/03/2023 ~
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour, IDataPersistence
{
    EricInteraction diaInterRef;
    QuestDisplayManager qdmQuestRef;

    public bool bHammerFound = false;

    // Start is called before the first frame update
    void Start()
    {
        diaInterRef = FindAnyObjectByType<EricInteraction>();
        qdmQuestRef = FindAnyObjectByType<QuestDisplayManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bHammerFound = true;
            diaInterRef.HammerFound();
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
