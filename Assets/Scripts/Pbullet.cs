using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pbullet : MonoBehaviour
{
    bool stp2 = false;
    //bool mtht2 = false;
    bool dsph = false;
    [SerializeField] AudioClip MthtS2 = null;
    [SerializeField] GameObject bpartc2;
    [SerializeField] GameObject bpartc3;
    [SerializeField] GameObject bpartc4;
    Transform rorg;
    float shootdist;
    bool spawn3 = false;
    int tstr;
    public bool setdised = true;
    // Start is called before the first frame update
    void Start()
    {
        rorg = GameObject.Find("Gun end").transform;
        Destroy(this.gameObject, 5f);
        //was60f
        shootdist = 40f;
        //DelayHelper.DelayAction(this, chckspa, .2f);
        // upd
    }
    //private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    {
        //mtht2 = true;
        //Rigidbody rbepb2 = this.GetComponent<Rigidbody>();
        //rbepb2.AddForce(-rbepb2.velocity, ForceMode.VelocityChange);
        //rbepb2.velocity = Vector3.zero;
        //Destroy(rbepb2);
        if (other.tag != "Ladder")
        {
            if (other.tag != "HangS")
            {
                if (other.tag != "Slope")
                {
                    if (other.tag != "mplt")
                    {
                        if (other.tag != "boostblock")
                        {

                            //GameObject bprt4 = Instantiate(bpartc4, this.transform.position, this.transform.rotation);
                            //Destroy(bprt4, .5f);
                            sdstrct2();
                        }
                    }
                }
            }
        }
    }

        // Update is called once per frame
    void Update()
    {
        //dsph = Physics.CheckSphere(transform.position, .31f);
        //if (dsph == true)
        //{
        //sdstrct2();
        //}
        //if (setdised == true)
        //{

        //Collider[] colliders = Physics.OverlapCapsule(this.transform.position, this.transform.forward * 3f, .1f);
          //Collider[] colliders = Physics.OverlapSphere(this.transform.position, .1f);

          //foreach (Collider collider in colliders)
          //{
            // Check if the detected object is different from the object this script is attached to.
            //if (collider.gameObject != gameObject)
              //if (collider.tag == "Enemyt")
              //{
                  //spawn3 = false;
                //Debug.Log("Object detected: " + collider.gameObject.name);
                // You can perform any actions or logic here for the detected objects.
              //}
          //}

        shootdist = Shooting.Pshootdis;
        //}
        if (Vector3.Distance(rorg.position, this.transform.position) > shootdist)
        {
            Rigidbody rbepb = this.GetComponent<Rigidbody>();
            rbepb.velocity = Vector3.zero;
            spawn3 = true;
            sdstrct2();
        }
    }
    void sdstrct2()
    {
        //if (mtht2 == true)
        //{
        //AudioHelper.PlayClip2D(MthtS2);
        //mtht2 = false;
        //}
        //Debug.Log(spawn3);
        GameObject bprt2 = Instantiate(bpartc2, this.transform.position, this.transform.rotation);
        if (spawn3 == true)
        {
            //Debug.Log(spawn3);
            GameObject bprt3 = Instantiate(bpartc3, this.transform.position, this.transform.rotation);
            Destroy(bprt3, .5f);
        }
          //if (spawn3 == false)
           //{
            //Debug.Log(spawn3);
              //GameObject bprt4 = Instantiate(bpartc4, this.transform.position, this.transform.rotation);
              //Destroy(bprt4, .5f);
          //}
        Destroy(bprt2, .5f);
        Destroy(this.gameObject);
        //GameObject.Destroy(gameObject);
    }
}
