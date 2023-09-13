using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantPhaseController : MonoBehaviour
{
    public Animator animator;
    private float tick;
    // Start is called before the first frame update
    void Start()
    {
        tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tick < 25 || animator.GetBool("enableWilt"))
        {
            tick = tick + 0.01f;
            animator.SetFloat("plant_age", tick);
        }
    }
}
