using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    [SerializeField] float fWatchDetectDistance = 5f;
    [SerializeField] float fLightDuration = 1f;
    [SerializeField] GameObject lightPrefab;

    float fStartingCooldown = 15f;
    float fCooldownTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (fCooldownTime > 0)
        {
            fCooldownTime -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, fWatchDetectDistance); //get all objects within range
                foreach (Collider c in colliders)
                {
                    if (c.gameObject.tag == "Trap")
                    {
                        GameObject goTrapLight = Instantiate(lightPrefab, c.gameObject.transform.position, transform.rotation);
                        Destroy(goTrapLight, fLightDuration);
                    }
                }
                fCooldownTime = fStartingCooldown;
            }
        }
    }
}
