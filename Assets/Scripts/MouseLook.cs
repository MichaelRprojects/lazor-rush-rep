using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;
    bool aimedt = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (PMovement.isdead == false && Level01Controller.pgpaused == false)
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            //}
        }
            if (PMovement.isdead == false && Level01Controller.pgpaused == false)
        {
            //was *500f * Time.deltaTime; at end next 2
            float mouseX = Input.GetAxis("Mouse X") * 5f;
            float mouseY = Input.GetAxis("Mouse Y") * 5f;

            if (Melee.isbswing == false)
            {
                xRotation -= mouseY;

                aimedt = false;
            }
            //issbswing
            if (Melee.isbswing == true && Melee.targets == null)
            {
                xRotation -= mouseY;
            }
            //Debug.Log(Melee.targets);
            if (Melee.isbswing == true && Melee.targets != null)
            {
                //if (Melee.targets != null)
                //{
                //float mtarg = Melee.targets.transform.position - this.transform.position;
                //xRotation -= Melee.targets.transform.position - this.transform.position;
                //transform.localRotation = Quaternion.Euler(Melee.targets.transform.position) * Quaternion.Euler(45,0,0);
                //Quaternion lkrt = Quaternion.Euler(Melee.targets.transform.position) * Quaternion.Euler(45, 0, 0);
                //xRotation -= mouseY;
                //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                //playerBody.Rotate(Vector3.up * mouseX);

                //x 45 y+10 0
                //Quaternion lkrt = Quaternion.Euler(Melee.targets.transform.position);
                if (aimedt == false)
                {
                    DelayHelper.DelayAction(this, amdtt, .05f);
                    Quaternion lkrt = Quaternion.Euler(Melee.targets.transform.position.x + 45, Melee.targets.transform.position.y + 10, 0);
                    //50f
                    transform.localRotation = Quaternion.RotateTowards(transform.localRotation, lkrt, Time.deltaTime * 100f);
                }
                //}
            }
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            if (Melee.isbswing == false)
            {
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX);
            }
            //isbswing
            if (Melee.isbswing == true && Melee.targets == null)
                {
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            }
        }
        if (PMovement.isdead == true || Level01Controller.pgpaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void amdtt()
    {
        aimedt = true;
    }
}
