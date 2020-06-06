using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{   
    private LevelManager levelManager;

    public int coinValue = 1;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player") {
            levelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
        
    }
}
