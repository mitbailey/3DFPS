using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisHandler : MonoBehaviour
{
    int WAIT_TIME = 3;
    float SCORE_DEPTH = -2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DepthChecker());
    }

    IEnumerator DepthChecker()
    {
        for (;;)
        {
            yield return new WaitForSeconds(WAIT_TIME);

            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Debris"))
            {
                if (go.transform.position.y < SCORE_DEPTH)
                {
                    Destroy(go);
                    Debug.Log("SCORE!");
                }
            }
        }
    }
}