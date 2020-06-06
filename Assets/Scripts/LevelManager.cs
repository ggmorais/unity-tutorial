using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{  
    public float respawnDelay = 2f;
    public PlayerController player;
    public int coins;
    public Text coinText;
    public Sprite lifeSprite;
    public GameObject lifePanel;

    private int lifes;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lifes = player.lifes;
    }

    void Update()
    {

    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = player.respawnPoint;
        player.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsNumber)
    {
        coins += coinsNumber;
        coinText.text = coins.ToString();
    }

    public void AddLifes(int lifeNumber)
    {   
        for (int i = 0; i < lifeNumber; i++) {
            GameObject lifeObj = new GameObject();
            Image lifeImg = lifeObj.AddComponent<Image>();
            lifeImg.sprite = lifeSprite;
            lifeObj.GetComponent<RectTransform>().SetParent(lifePanel.transform);
            lifeObj.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
            lifeObj.transform.position = lifePanel.transform.position;

            lifeObj.transform.position = new Vector2(lifeObj.transform.position.x + (45 * i), lifeObj.transform.position.y);

            lifeObj.SetActive(true);
        }

    }

    public void RemoveLifes(int lifeNumber)
    {   
        if (lifeNumber == 1) {
            Destroy(lifePanel.transform.GetChild(lifePanel.transform.childCount - 1).gameObject);
        }

        for (int i = 1; i < lifeNumber; i++) {
            Destroy(lifePanel.transform.GetChild(lifePanel.transform.childCount - i).gameObject);
        }
        
    }
}
