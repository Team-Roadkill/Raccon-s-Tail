/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 17/02/2023
/// Purpose :  
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedroomUI : MonoBehaviour
{
    DataPersistenceManager dpmDataPersistanceManager;

    [Header("Menus")]
    [SerializeField] GameObject goPlayGameSelection;
    [SerializeField] GameObject goNewGameSelection;
    [SerializeField] GameObject goSettingsMenu;
    [SerializeField] GameObject goSidebarMenu;


    [Header("LoadGame")]
    [SerializeField] GameObject goSaveListContainer;
    [SerializeField] GameObject goSaveEntryPrefab;


    [Header("NewGame")]
    [SerializeField] Text goNewGameFileNameField;

    [Header("InScene")]
    [SerializeField] GameObject PlayerReference;
    [SerializeField] GameObject SleepingEffect;

    [SerializeField] bool PlayerStartsHidden = true;

    // Start is called before the first frame update
    void Start()
    {
        dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>();
        goSidebarMenu.SetActive(true);
        SleepingEffect.SetActive(true);
        if (PlayerStartsHidden == true)
        {
            PlayerReference.SetActive(false);
        }
        else
        {
            PlayerReference.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// show the saves that can be loaded
    /// </summary>
    public void PlayButton()
    {
        goNewGameSelection.SetActive(false);
        goSettingsMenu.SetActive(false);
        if (goPlayGameSelection.gameObject.activeSelf == true)
        {
            goPlayGameSelection.SetActive(false);
        }
        else
        {
            goPlayGameSelection.SetActive(true);
        }


        string[] sFilesFound = dpmDataPersistanceManager.GetAllFilesWithinSaveDir();
        foreach (Transform t in goSaveListContainer.transform) //each child within the container
        {
            GameObject.Destroy(t.gameObject); //destry gameobject
        }

        foreach (string s in sFilesFound) //for each save found
        {
            GameObject go = Instantiate(goSaveEntryPrefab); //create save entry
            go.transform.SetParent(goSaveListContainer.transform); //set parent
            GameObject g = go.transform.Find("SaveName").gameObject; //get text component
            g.GetComponent<Text>().text = s; //set text to found save name
        }
    }

    /// <summary>
    /// play the selected save file
    /// </summary>
    public void PlaySaveButton(GameObject a_goButton)
    {
        string tButtonText = a_goButton.transform.Find("SaveName").GetComponent<Text>().text; //get displayed save name of button that called

        dpmDataPersistanceManager.fileName = tButtonText; //set working file name
        dpmDataPersistanceManager.SetSavePath(); //setup working path
        //SceneLoader.Load(SceneLoader.Scene.DenScene); //load den scene
        //dpmDataPersistanceManager.LoadGame(); //load save data
        PlayerReference.SetActive(true); //enable player
        SleepingEffect.SetActive(false); //disable sleep effect
        goSidebarMenu.SetActive(false); //hide side bar
        goPlayGameSelection.SetActive(false); //hide current menu
    }

    /// <summary>
    /// close play pop up
    /// </summary>
    public void ClosePlayPopup()
    {
        goPlayGameSelection.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    public void NewGameButton()
    {
        goPlayGameSelection.SetActive(false);
        goSettingsMenu.SetActive(false);
        if (goNewGameSelection.gameObject.activeSelf == true)
        {
            goNewGameSelection.SetActive(false);
        }
        else
        {
            goNewGameSelection.SetActive(true);
        }
    }

    /// <summary>
    /// load the selected save file
    /// </summary>
    public void NewSaveConfirmButton()
    {
        string sInputText = goNewGameFileNameField.GetComponent<Text>().text; //referance input text
        string[] sSaveFilesFound = dpmDataPersistanceManager.GetAllFilesWithinSaveDir(); //list of existing save names
        bool bCanUseName = true; //store if this naem can be used
        foreach (string s in sSaveFilesFound)
        {
            if (s == sInputText)
            {
                bCanUseName = false; //if name found this name is not useable
            }
        }

        if (bCanUseName) //if name is useable
        {
            //get selected save
            dpmDataPersistanceManager.fileName = sInputText; //set new save working dir name to input name
            dpmDataPersistanceManager.SetSavePath(); //setup working path

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //first load ever stuff in here

            //temp in here
            PlayerReference.SetActive(true); //display player
            SleepingEffect.SetActive(false); //disable sleep effect

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //SceneLoader.Load(SceneLoader.Scene.DenScene); //load den scene
            //dpmDataPersistanceManager.LoadGame(); //load save data
            goSidebarMenu.SetActive(false);
            goNewGameSelection.SetActive(false);
        }
    }

    /// <summary>
    /// close new game popup
    /// </summary>
    public void CloseNewGamePopup()
    {
        goNewGameSelection.SetActive(false);
    }

    /// <summary>
    /// display the settings menu
    /// </summary>
    public void SettingsButton()
    {
        goPlayGameSelection.SetActive(false);
        goNewGameSelection.SetActive(false);
        //show settings menu
        if (goSettingsMenu.gameObject.activeSelf == true)
        {
            goSettingsMenu.SetActive(false);
        }
        else
        {
            goSettingsMenu.SetActive(true);
        }
    }

    /// <summary>
    /// display the settings menu
    /// </summary>
    public void SettingsCloseButton()
    {
        //show settings menu
        goSettingsMenu.SetActive(false);
    }

    /// <summary>
    /// on exit button press quit application
    /// </summary>
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Application.Quit(); - has been run"); //for unity editor view
    }
}
