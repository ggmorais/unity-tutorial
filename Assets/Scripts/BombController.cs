using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{   
    public int damage = 1;
    public float timer = 3f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        StartCoroutine("ExplodeCoroutine");
    }

    void Update()
    {
        
    }

    public IEnumerator ExplodeCoroutine()
    {
        yield return new WaitForSeconds(timer);
        animator.SetBool("Exploded", true);
    }
}
