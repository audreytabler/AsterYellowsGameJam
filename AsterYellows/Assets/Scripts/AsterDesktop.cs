using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsterDesktop : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
