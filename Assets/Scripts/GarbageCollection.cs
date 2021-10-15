using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollection : MonoBehaviour
{
    float CLEANUP_RADIUS = 100f;
    int WAIT_TIME = 60;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GarbageCollectionCoroutine());
    }

    IEnumerator GarbageCollectionCoroutine()
    {
        for (;;)
        {
            yield return new WaitForSeconds(WAIT_TIME);

            int DelCount = 0;
            
            foreach(GameObject go in FindObjectsOfType<GameObject>())
            {
                if (Vector3.Distance(new Vector3(0f, 0f, 0f), go.transform.position) > CLEANUP_RADIUS)
                {
                    Destroy(go);
                    DelCount++;
                }
            }

            Debug.Log("Cleaned up " + DelCount + " items.");
        }
    }
}
