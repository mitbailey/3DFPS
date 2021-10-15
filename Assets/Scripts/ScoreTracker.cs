using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public GameObject ScoreDisplay;
    Text ScoreText;
    int score = 0;
    float WAIT_TIME = 0.25f; 

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = ScoreDisplay.GetComponent<Text>();
        ScoreText.text = score.ToString() + " PENALTY PTS";

        StartCoroutine(TimePenalties());
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString() + " PENALTY PTS";
    }

    public void IncreaseScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    IEnumerator TimePenalties()
    {
        for (;;)
        {
            yield return new WaitForSeconds(WAIT_TIME);

            IncreaseScore();
        }
    }
}