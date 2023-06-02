using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DenCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider a_cColliderInfo)
    {

        if (a_cColliderInfo.name == "ExitRoom")
        {
            SceneLoader.Load(SceneLoader.Scene.DenScene);
        }

        if (a_cColliderInfo.name == "Tunnel")
        {
            //SceneLoader.Load(SceneLoader.Scene.Testing_Chris);
            SceneLoader.Load(SceneLoader.Scene.HouseScene);
        }

    }
}
