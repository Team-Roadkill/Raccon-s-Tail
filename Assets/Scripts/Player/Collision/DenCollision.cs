using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DenCollision : MonoBehaviour
{
    [SerializeField] Text tInteractText;


    private void OnTriggerEnter(Collider a_cColliderInfo)
    {
        tInteractText.gameObject.SetActive(true);
        //tInteractText.gameObject.transform =;

        if (a_cColliderInfo.name == "Door" || a_cColliderInfo.name == "ExitRoom")
        {
            if (SceneManager.GetActiveScene().name == "MenuScene" || SceneManager.GetActiveScene().name == "DenBedroom")
            {
                SceneLoader.Load(SceneLoader.Scene.DenScene);
            }
            else if (SceneManager.GetActiveScene().name == "DenScene")
            {
                SceneLoader.Load(SceneLoader.Scene.MenuScene);
            }
        }

        if (a_cColliderInfo.name == "Tunnel")
        {
            SceneLoader.Load(SceneLoader.Scene.HouseScene);
        }

    }
}
