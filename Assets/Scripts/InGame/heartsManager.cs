using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartsManager : MonoBehaviour
{
    [SerializeField] ExitLevel exitLevelRef;
    [SerializeField] GameObject heartOne;
    [SerializeField] GameObject heartTwo;
    [SerializeField] GameObject heartThree;

    [SerializeField] float TimeBetweenDamage;
    float fTimer;

    int totalHearts = 3;

    private void Update()
    {
        if (fTimer >= 0)
        {
            fTimer -= Time.deltaTime;
        }
    }

    public void RegenOneHeart()
    {
        totalHearts++;
        updateHearts();
    }

    public void TakeOneHeartDamage()
    {
        if (fTimer <= 0)
        {
            fTimer = TimeBetweenDamage;
            totalHearts--;
            updateHearts();
        }
    }


    void updateHearts()
    {
        //hide all
        heartOne.SetActive(false);
        heartTwo.SetActive(false);
        heartThree.SetActive(false);


        //show needed hearts
        if (totalHearts >= 3)
        {
            heartThree.SetActive(true);
        }
        if (totalHearts >= 2)
        {
            heartTwo.SetActive(true);
        }
        if (totalHearts >= 1)
        {
            heartOne.SetActive(true);
        }

        //if no hp die
        if (totalHearts <= 0)
        {
            exitLevelRef.Death();
        }
    }

}
