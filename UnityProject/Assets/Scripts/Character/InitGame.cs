using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text hsText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.globalScore;
        hsText.text = "HS: " + GameManager.highScore;

        ScoreCompare();
    }

    void ScoreCompare()
    {
        if(GameManager.highScore < GameManager.globalScore)
        {
            GameManager.highScore = GameManager.globalScore;
        }
    }
}
