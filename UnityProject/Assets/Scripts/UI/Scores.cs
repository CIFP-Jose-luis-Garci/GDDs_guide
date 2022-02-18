using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text higScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.globalScore.ToString();
        higScoreText.text = GameManager.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
