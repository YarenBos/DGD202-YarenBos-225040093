using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    private int score;
    public int scoringAmount;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gem")
        {
            AudioManager.instance.PlaySFX(0);
            score += scoringAmount;
            scoreText.text = "SCORE : " + score;
            Destroy(collision.gameObject);
            Debug.Log(score);

        }
    }
}
