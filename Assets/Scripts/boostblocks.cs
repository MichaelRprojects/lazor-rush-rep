using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostblocks : MonoBehaviour
{
    GameObject Pl;
    CharacterController playercontoller;
    Vector3 initialPlayerPosition;
    Vector3 launchVelocity;
    bool isLaunching = false;
    public float launchForce = 70f;
    float launchTimer = 0f;
    float launchDuration = 2f;
    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;
    [SerializeField] AudioClip launchS = null;
    // Start is called before the first frame update
    void Start()
    {
        Pl = GameObject.Find("Player");
        playercontoller = Pl.GetComponent<CharacterController>();
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Pl)
        {
            //launch();
            launchTimer = 0f;
            DelayHelper.DelayAction(this, launch, .25f);
            //AudioHelper.PlayClip2D(launchS);
            AudioHelperExclude.PlayClip2D(launchS);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Pl)
        {
            //DelayHelper.DelayAction(this, launchfalse, 1f);
        }
    }
            // Update is called once per frame
    void Update()
    {
       if (isLaunching == true)
        {
            //Vector3 launchDirection = Vector3.up * launchForce * (1 - launchTimer / launchDuration);
            //playerController.Move(launchDirection * Time.deltaTime);

            //Vector3 launchDirection = Vector3.up * launchForce;
            //playercontoller.Move(launchDirection * Time.deltaTime);

            launchTimer += Time.deltaTime;
            float currentForce = launchForce * (1 - launchTimer / launchDuration);
            Vector3 launchDirection = launchVelocity.normalized * currentForce * Time.deltaTime;
            playercontoller.Move(launchDirection);
            if (launchTimer >= launchDuration)
            {
                isLaunching = false;
                launchTimer = 0f;
            }
        }
    }
    void LateUpdate()
    {
        transform.localPosition = initialLocalPosition;

        // Reset the local rotation of the object
        transform.localRotation = initialLocalRotation;

        // Traverse through the hierarchy of parents and counteract their rotations
        Transform currentParent = transform.parent;
        while (currentParent != null)
        {
            transform.localRotation *= Quaternion.Inverse(currentParent.localRotation);
            currentParent = currentParent.parent;
        }
    }
    void launch()
    {
        //initialPlayerPosition = playercontoller.transform.position;

        //launchVelocity = Vector3.up * launchForce;
        launchVelocity = this.transform.up * launchForce;
        isLaunching = true;
    }
    void launchfalse()
    {
        isLaunching = false;
    }
}
