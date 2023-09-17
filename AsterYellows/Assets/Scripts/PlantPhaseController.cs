using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantPhaseController : MonoBehaviour
{
    public Animator animator;
    public float tick;
    public static bool enableWilt;

    //public float timeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        enableWilt = false;
        tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tick < 24)
        {
            tick = tick + GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().timeSpeed;
            animator.SetFloat("plant_age", tick);
        }/*
        else if (enableWilt)
        {
            tick = tick + GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>().timeSpeed;
            animator.SetFloat("plant_age", tick);
        }*/
    }
}
