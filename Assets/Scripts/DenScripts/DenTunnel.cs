/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/01/2023
/// Purpose : Tunnel script for going to a new scene from the den
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// maybe switch collision to player
/// </summary>

public class DenTunnel : MonoBehaviour
{

    [SerializeField]
    SceneLoader.Scene sSceneToLoad; //what scene will be loaded on interaction

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //if collsion with player named object
        {
            //display interact text
            if (Input.GetKeyDown("E")) //if e pressed
            {
                SceneLoader.Load(sSceneToLoad); //load a scene
            }
        }
    }
}
