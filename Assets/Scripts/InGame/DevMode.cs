/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 01/03/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevMode : MonoBehaviour
{
    [SerializeField] GameObject DevMenu; //dev menu ref
    DataPersistenceManager dpmDataPersistanceManager;

    [SerializeField] GameObject GameScene;
    [SerializeField] GameObject TestingArea;
    [SerializeField] GameObject Basement;
    [SerializeField] GameObject Player;
     Vector3 PlayerLocation = new Vector3(33.3419991f,8.69999981f,62.3330002f);


    bool paused = false;

    private void Start()
    {
        //dpmDataPersistanceManager = GameObject.FindGameObjectWithTag("DataPersistanceManager").GetComponent<DataPersistenceManager>();
        //dpmDataPersistanceManager = FindAnyObjectByType<DataPersistenceManager>();

        //DevMenu.SetActive(false); //hide dev menu
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.M)) //if both left ctrl and m pressed
        {
            DevMenu.SetActive(true); //show dev menu
            Cursor.lockState = CursorLockMode.None; // unlock cursor so shown
        }
        else if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.M)) //if both esc and m pressed
        {
            DevMenu.SetActive(false); //hide dev menu
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.P))
        {
            dpmDataPersistanceManager.SaveGame();
            SceneLoader.Load(SceneLoader.Scene.DenScene);
        }

        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.L))
        {
            dpmDataPersistanceManager.LoadGame();
        }

    }


    /// <summary>
    /// switch to the testing area
    /// </summary>
    public void LoadTestingArea()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = PlayerLocation;
        Player.GetComponent<CharacterController>().enabled = true;
        TestingArea.SetActive(true);
        GameScene.SetActive(false);
        Basement.SetActive(false);
    }

    /// <summary>
    /// switch to the game area
    /// </summary>
    public void LoadGameScene()
    {
         Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = new Vector3(107.709999f,-8.78999996f,171.009995f);
        Player.GetComponent<CharacterController>().enabled = true;
        GameScene.SetActive(true);
        TestingArea.SetActive(false);
         Basement.SetActive(false);
    }

/// <summary>
    /// switch to the game area
    /// </summary>
    public void LoadBasement()
    {
         Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = PlayerLocation;
        Player.GetComponent<CharacterController>().enabled = true;
        GameScene.SetActive(false);
        TestingArea.SetActive(false);
        Basement.SetActive(true);
    }





    /// <summary>
    /// reload the active sceme
    /// </summary>
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// toggle the timescale of the game
    /// </summary>
    public void TogglePause()
    {
        if (paused == true)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
        }
    }











}
