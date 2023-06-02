/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 04/03/2023
/// Purpose : keep track of the quests the player has displaying them as a list and being able to add and remove them when called
/////////////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplayManager : MonoBehaviour, IDataPersistence
{
    //ui display area
    //blank quest obj
    [SerializeField] GameObject goQuestCell; //individual quest obj prefab
    [SerializeField] GameObject goQuestContainer; //container for quests
    public Dictionary<int, string> li_isQuests = new Dictionary<int, string>(); //list of active quests


    private void Start()
    {
        //AddNewQuest(1, "QuestTest");
    }

    /// <summary>
    /// add new quest to dictionary
    /// </summary>
    public void AddNewQuest(int a_iQuestID, string a_sQuestObjectiveText)
    {
        if (li_isQuests.ContainsKey(a_iQuestID) == false) //ensure no duplicate quest ids
        {
            li_isQuests.Add(a_iQuestID, a_sQuestObjectiveText); //add quest
            UpdateQuestDisplay(); //update quest display
        }
    }


    /// <summary>
    /// if quest id is in the list remove it
    /// </summary>
    public void RemoveQuest(int a_iQuestIDToRemove)
    {
        Debug.Log("Quest remove attempt");
        if (li_isQuests.ContainsKey(a_iQuestIDToRemove) == true)
        {
            li_isQuests.Remove(a_iQuestIDToRemove); //remove quest
            UpdateQuestDisplay(); //update quest display
        }

    }

    /// <summary>
    /// update ingame dispaly of quests 
    /// </summary>
    public void UpdateQuestDisplay()
    {
        foreach (Transform childTransform in goQuestContainer.transform)
        {
            Destroy(childTransform.gameObject);
        }


        //looping though all quests to ensure nothing has been incorrectly updated /added/removed
        foreach (KeyValuePair<int, string> kvp in li_isQuests) 
        {
            if (DevSettings.devModeEnabled == true)
            {
                GameObject goNewQuest = Instantiate(goQuestCell, goQuestContainer.transform.position, goQuestContainer.transform.rotation, goQuestContainer.transform); //create new cell at container pos/rot
                //goNewQuest.transform.SetParent(goQuestContainer.transform); //set parent to container
                goNewQuest.transform.GetChild(0).gameObject.GetComponent<Text>().text = kvp.Key + ":" + kvp.Value; //update test display with key and value
            }
            else
            {
                GameObject goNewQuest = Instantiate(goQuestCell, goQuestContainer.transform.position, goQuestContainer.transform.rotation, goQuestContainer.transform); //create new cell at container pos/rot
                //goNewQuest.transform.SetParent(goQuestContainer.transform); //set parent to container
                goNewQuest.transform.GetChild(0).gameObject.GetComponent<Text>().text = "-" + kvp.Value; //update test display with value
            }
        }
    }

    /// <summary>
    /// load active quests from save
    /// </summary>
    /// <param save data="gdData"></param>
    public void LoadData(GameData gdData)
    {
        foreach (KeyValuePair<int, string> savedQuests in gdData.isActiveQuests)
        {
            li_isQuests.Add(savedQuests.Key, savedQuests.Value);
        }
    }

    /// <summary>
    /// save active quests to file
    /// </summary>
    /// <param save data="gdData"></param>
    public void SaveData(ref GameData gdData)
    {
        foreach (KeyValuePair<int, string> sd in gdData.isActiveQuests)
        {
            gdData.isActiveQuests.Remove(sd.Key);
        }
        foreach (KeyValuePair<int, string> savedQuests in gdData.isActiveQuests)
        {
            gdData.isActiveQuests.Add(savedQuests.Key, savedQuests.Value);
        }
    }
}