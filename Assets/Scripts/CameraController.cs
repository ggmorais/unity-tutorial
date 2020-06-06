using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 playerPos;

    public GameObject player;
    public float offset = 3f;
    public float offsetSmoothing = 2f;

    void Start()
    {

    }


    void Update()
    {   
        playerPos = player.transform.position;

        var posX = 0f;

        if (player.transform.localScale.x > 0f) {
            posX = playerPos.x + offset;
        } else if (player.transform.localScale.x < 0f) {
            posX = playerPos.x - offset;
        }

        playerPos = new Vector3(
            posX, 
            transform.position.y, 
            transform.position.z
        );
        
        transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmoothing * Time.deltaTime);
    }
}
