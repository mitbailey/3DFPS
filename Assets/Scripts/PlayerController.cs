using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float AzMult = 75f;
    float ElMult = 75f;
    float FBMult = 0.1f;
    float LRMult = 0.1f;
    float ShMult = 2f;

    public GameObject PlayerHead;
    public Rigidbody PlayerRB;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Az = Input.GetAxis("Mouse X") * AzMult;
        float El = Input.GetAxis("Mouse Y") * ElMult;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            transform.Rotate(Vector3.up, Az * Time.deltaTime);
            PlayerHead.transform.Rotate(Vector3.left, El * Time.deltaTime);
        }
        
    }

    void FixedUpdate()
    {
        float FB = Input.GetAxis("Vertical") * FBMult;
        float LR = Input.GetAxis("Horizontal") * LRMult;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            FB *= ShMult;
            LR *= ShMult;
        }

        PlayerRB.MovePosition(transform.position + transform.TransformDirection(new Vector3(LR, 0f, FB)));
        PlayerRB.AddRelativeForce(new Vector3(0f, Input.GetKeyDown(KeyCode.Space) ? 10f : 0f, 0f), ForceMode.Impulse);
    }
}
