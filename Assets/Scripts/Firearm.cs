using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : MonoBehaviour
{   
    public GameObject Universe;
    public GameObject PlayerHead;
    public GameObject projectile_prefab;
    ScoreTracker st;

    // Start is called before the first frame update
    void Start()
    {
        st = Universe.GetComponent<ScoreTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            st.IncreaseScore();
            GameObject projectile = Instantiate(projectile_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z) + PlayerHead.transform.TransformDirection(new Vector3(0f, 0f, 1.5f)), Quaternion.identity);
            Rigidbody projectile_rb = projectile.GetComponent<Rigidbody>();
            projectile_rb.AddForce(PlayerHead.transform.TransformDirection(new Vector3(0f, 0f, 8f)), ForceMode.Impulse);
        }
    }
}
