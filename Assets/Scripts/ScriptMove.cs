using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMove : MonoBehaviour
{
    private Transform sp1Trans;
    public float movePercent = 0.01f;
    private Animator animator;

    void Start()
    {
        sp1Trans = GameObject.Find("Script1").transform;
        animator = GetComponent<Animator>();
        animator.Play("WalkScript");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, sp1Trans.position, movePercent);
    }
}
