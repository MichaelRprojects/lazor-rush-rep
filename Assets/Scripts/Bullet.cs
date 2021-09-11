using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //GameObject hsp;
    bool stp = false;
    bool mtht = false;
    bool plyrflct = true;
    public static bool isreflct = false;
    [SerializeField] AudioClip MthtS = null;
    [SerializeField] AudioClip RtrnhtS = null;
    [SerializeField] GameObject rpartc;
    [SerializeField] GameObject eklr;
    //public float stimer;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Enemyt")
        //{
            //eklr.SetActive(false);
        //}
            if (other.tag == "pshield")
        {
            //isreflct = true;
            eklr.SetActive(true);
            //Renderer bren = this.GetComponent<Renderer>();
            //bren.material.color = Color.blue;
            Rigidbody rthb = this.GetComponent<Rigidbody>();
        rthb.velocity = Vector3.zero;
        rthb.AddForce(-transform.forward * 32f, ForceMode.Impulse);
            if (plyrflct == true)
            {
                AudioHelper.PlayClip2D(RtrnhtS);
                plyrflct = false;
            }
        }
        if (other.tag == "shield")
        {
        sdstrct();
        }
        //|| other.tag != "shield"
        if (other.tag != "pshield" && other.tag != "shield" && other.tag != "mplt")
        {
            mtht = true;
            sdstrct();
        }
        //if (other.tag == "Plyr")
        //{
            //stp = true;
        //}
    }
    // Update is called once per frame
    void Update()
    {
        DelayHelper.DelayAction(this, sdstrct, 3f);
        if (stp == true)
        {
            sdstrct();
        }
    }
    void sdstrct()
    {
        if (mtht == true)
        {
            AudioHelper.PlayClip2D(MthtS);
            mtht = false;
        }
        GameObject rprt = Instantiate(rpartc, this.transform.position, this.transform.rotation);
        Destroy(rprt, .5f); 
        Destroy(this.gameObject);
        //GameObject.Destroy(gameObject);
    }
}
