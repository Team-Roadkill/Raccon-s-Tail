/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 30/01/2023
/// Purpose : functions that update coins
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void HideCoin()
    {
        gameObject.GetComponent<Renderer>().enabled = false; //hide the item once its been collected
        gameObject.GetComponent<Collider>().enabled = false; //prevent the player from colliding now the items been colected
    }
}
