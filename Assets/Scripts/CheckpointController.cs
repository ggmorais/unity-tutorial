using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    public Sprite redFlag;
    public Sprite greenFlag;
    public bool reached;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player) {
        if (player.tag == "Player") {
            spriteRenderer.sprite = greenFlag;
            reached = true;
        }
    }
}
