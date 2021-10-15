using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class HighScoreHandler : MonoBehaviour
{
    public GameObject ScoresDisplay;
    Text ScoresText;

    // Start is called before the first frame update
    void Start()
    {
        ScoresText = ScoresDisplay.GetComponent<Text>();

        StartCoroutine(ScoresUpdater());
    }

    IEnumerator ScoresUpdater()
    {
        for(;;)
        {
            yield return new WaitForSeconds(1);

            if (!File.Exists("scores.txt"))
            {
                System.IO.File.WriteAllText("scores.txt", "SCORES:\n");
            }

            string scores = File.ReadAllText("scores.txt");
            ScoresText.text = scores;
        }   
    }
}
