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
    QuestDisplayManager QuestDisplayManagerRef;

    public bool bHammerFound = false;

    public int iQuestID; //id of the quest this script gives //new id
    public int iHandinQuestID; //id of the quest that needs to be cleared // erics
    public string sQuestDialog; //what the quest area dialog is going to be

    // Start is called before the first frame update
    void Start()
    {
        diaInterRef = FindAnyObjectByType<EricInteraction>();
        QuestDisplayManagerRef = FindAnyObjectByType<QuestDisplayManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bHammerFound = true;

            QuestDisplayManagerRef.RemoveQuest(iHandinQuestID);
            QuestDisplayManagerRef.AddNewQuest(iQuestID, sQuestDialog);

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
