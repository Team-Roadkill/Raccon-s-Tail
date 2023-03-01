/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 29/01/2023
/// Purpose : interface to interact with when to save/load
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage config")]
    public string fileName; //file name that will be used to store/load save
    [SerializeField]
    private bool bUseEncryption; //should the file be saved and read with encryption

    private GameData gdGameData; //data that will be saved
    private List<IDataPersistence> idpDataPersistenceObjects; //objects containing scripts with persistant data

    private FileDataHandler fdhDataHandler; //script that handles reading and writing to file

    public static DataPersistenceManager instance { get; private set; } //public instance that can only be privately edited

    private void Awake()
    {
        if (instance != null) //check for only one instance
        {
            Debug.LogError("Found more than one instance of the data persistence manager within the scene");
        }
        instance = this; //set instance to this object

        DontDestroyOnLoad(this.gameObject); //keep active between scenes

        if (Directory.Exists(Application.persistentDataPath + "/Saves/") == false) //if save folder doesnt exist
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/"); //create save folder
        }

    }

    /// <summary>
    /// set the file path that will be loaded and saved to
    /// </summary>
    public void SetSavePath()
    {
        this.fdhDataHandler = new FileDataHandler(Application.persistentDataPath + "/Saves/", fileName, bUseEncryption); //file handler to use
        this.idpDataPersistenceObjects = FindAllDataPersistenceObjects(); //get all scripts with data to save
    }

    /// <summary>
    /// return all the files found in the save dir
    /// </summary>
    /// <returns></returns>
    public string[] GetAllFilesWithinSaveDir()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/Saves/");
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace(Application.persistentDataPath + "/Saves/", "");
            //files[i] = files[i].Replace(".game", "");
        }

        return files;
    }


    /// <summary>
    /// add a new data persistant script to list
    /// </summary>
    /// <param data persistant script to add="a_dpNewDP"></param>
    public void LoadNewDataPersistence(IDataPersistence a_dpNewDP) 
    {
        if (idpDataPersistenceObjects.Contains(a_dpNewDP) == false) //if new data persistence isnt already saved
        {
            this.idpDataPersistenceObjects.Add(a_dpNewDP); //add new data persistence 
        }
    }

    /// <summary>
    /// remove a data persistant script from the list
    /// </summary>
    /// <param name="a_dpNewDP"></param>
    public void UnLoadDataPersistence(IDataPersistence a_dpNewDP)
    {
        foreach (IDataPersistence idp in idpDataPersistenceObjects) //check each idp
        {
            if (idp == a_dpNewDP) //is argument matching idp
            {
                idpDataPersistenceObjects.Remove(idp); //remove entry
                break; //exit for
            }
        }
    }


    /// <summary>
    /// create a new gamedata to use
    /// </summary>
    public void NewGame()
    {
        this.gdGameData = new GameData();
    }

    /// <summary>
    /// load data from file to gamedata script
    /// </summary>
    public void LoadGame()
    {
        Debug.Log(fileName.ToString());
        //load any saved data from a file with the data handler
        this.gdGameData = fdhDataHandler.Load(); //returns null if no data to load


        //if no game to load load defaults
        if (this.gdGameData == null)
        {
            Debug.Log("No data found, Initializing to defaults");
            NewGame(); //create a new gamedata
        }

        this.idpDataPersistenceObjects = FindAllDataPersistenceObjects(); //add any active data persistence

        //remove if doesnt exist
        foreach (IDataPersistence idp in idpDataPersistenceObjects) //check each idp
        {
            if (idp == null) //is argument matching idp
            {
                idpDataPersistenceObjects.Remove(idp); //remove entry
                break; //exit for
            }
        }

        //send data to scripts that have saved data
        foreach (IDataPersistence dataPersistenceObj in idpDataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gdGameData); //send game data to scripts with data persistence
        }

    }

    /// <summary>
    /// save all data from data persistant scripts to file
    /// </summary>
    public void SaveGame()
    {
        this.idpDataPersistenceObjects = FindAllDataPersistenceObjects(); //add any active data persistence

        //remove if doesnt exist
        foreach (IDataPersistence idp in idpDataPersistenceObjects) //check each idp
        {
            if (idp == null) //is argument matching idp
            {
                idpDataPersistenceObjects.Remove(idp); //remove entry
                break; //exit for
            }
        }

        //send data to scripts that have saved data
        foreach (IDataPersistence dataPersistenceObj in idpDataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gdGameData); //run save data on idps
        }

        fdhDataHandler.Save(gdGameData); //pass in data to save to file
    }

    /// <summary>
    /// when game closed save game
    /// </summary>
    //private void OnApplicationQuit()
    //{
    //    SaveGame();
    //}

    /// <summary>
    /// find all data persistence scripts within the scene
    /// </summary>
    /// <returns>list of all active data persistence scripts</returns>
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
