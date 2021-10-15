using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LevelTracker : MonoBehaviour
{
    int WAIT_TIME = 2;
    public GameObject LevelDisplay;
    Text LevelText;
    int CurrentLevel = 0;
    public GameObject DebrisObject;
    public GameObject Universe;
    ScoreTracker st;

    // Start is called before the first frame update
    void Start()
    {
        st = Universe.GetComponent<ScoreTracker>();
        LevelText = LevelDisplay.GetComponent<Text>();
        LevelText.text = "LEVEL " + CurrentLevel.ToString();
        StartCoroutine(CompletionChecker());
    }

    IEnumerator CompletionChecker()
    {
        for (;;)
        {
            yield return new WaitForSeconds(WAIT_TIME);

            if (GameObject.FindGameObjectsWithTag("Debris").GetLength(0) <= 0)
            {
                NextLevel();
            }
        }
    }

    void NextLevel()
    {
        switch(CurrentLevel)
        {
            case 0:
            {
                Instantiate(DebrisObject, new Vector3(2f, 1f, 0f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(2f, 2f, 2f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(0f, 5f, 2f), Quaternion.identity);
                break;
            }
            case 1:
            {
                Instantiate(DebrisObject, new Vector3(2f, 1f, 1f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(1f, 2f, 3f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(3f, 3f, 4f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(4f, 4f, 3f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(3f, 5f, 2f), Quaternion.identity);
                Instantiate(DebrisObject, new Vector3(1f, 6f, 1f), Quaternion.identity);
                break;
            }
            default:
            {
                Debug.Log("GAME COMPLETE!");
                // Time.timeScale = 0;

                string scores = File.ReadAllText("scores.txt");
                File.Delete("scores.txt");
                scores += st.GetScore().ToString() + "\n";
                System.IO.File.WriteAllText("scores.txt", scores);

                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("MainMenu");

                return;
            }
        }

        CurrentLevel++;
        LevelText.text = "LEVEL " + CurrentLevel.ToString();
    }
}
