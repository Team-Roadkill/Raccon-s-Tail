using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

	[SerializeField] GameObject pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider a_cColliderInfo)
    {
        if(a_cColliderInfo.gameObject.tag == "Player")
        {
            a_cColliderInfo.gameObject.transform.position = pos.transform.position;
        }       
	

    }

}
