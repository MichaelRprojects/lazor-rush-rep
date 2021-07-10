using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] LayerMask Playerlb;
    [SerializeField] GameObject eexp;
    [SerializeField] Light mnlght;
    [SerializeField] AudioClip MnwS = null;
    Transform Plb;
    bool plwrn = true;
    float pdetrb = 10;
    bool pdetb;
    // Start is called before the first frame update
    void Start()
    {
        Plb = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "reflectb")
        {
            explodemn();
        }
        if (other.tag == "pexploden")
        {
            explodemn();
        }
        if (other.tag == "thrnswrd")
        {
            explodemn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PMovement.isdead == false)
        {
            pdetb = Physics.CheckSphere(transform.position, pdetrb, Playerlb);
            if (pdetb == true)
            {
                mnlght.intensity = 20;
                if (plwrn == true)
                {
                    AudioHelper.PlayClip2D(MnwS);
                    plwrn = false;
                }
                DelayHelper.DelayAction(this, explodemn, 1f);
            }
        }
    }
    public void explodemn()
    {
        GameObject eexpl = Instantiate(eexp, this.transform.position, this.transform.rotation);
        Destroy(eexpl, .75f);
        Destroy(this.gameObject);
    }
}
