/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 30/01/2023
/// Purpose : 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
