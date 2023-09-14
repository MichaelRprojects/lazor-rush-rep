using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockmakerscript : MonoBehaviour
{
    GameObject Pl;
    bool canbuzzsound = true;
    bool shocking = false;
    int maxshockamount = 35;
    public static float shockamount = 0;
    [SerializeField] AudioClip shckS = null;
    [SerializeField] AudioClip wrnS = null;
    private void OnTriggerStay(Collider other)
    {
        //PMovement pmovement
            //= other.gameObject.GetComponent<PMovement>();
        //if (pmovement != null)
        if(other.gameObject == Pl)
        {
            shocking = true;
        }
        //if (pmovement == null)
        //{
            //shocking = false;
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        //PMovement pmovement
        //= other.gameObject.GetComponent<PMovement>();
        //if (pmovement != null)
        shockamount = 0;
        if (other.gameObject == Pl)
        {
            shocking = false;
            //canwarnsound = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        AudioHelper.PlayClip2D(wrnS);
    }
        // Start is called before the first frame update
    void Start()
    {
        shockamount = 0;
        canbuzzsound = true;
        Pl = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (shocking == true)
        {
            if (shockamount < maxshockamount)
            {
                shockamount = Mathf.Clamp(shockamount + (30 * Time.deltaTime), 0.0f, maxshockamount);
            }
            if (shockamount >= (maxshockamount/4))
            {
                //if (canwarnsound == true)
                //{
                    //AudioHelper.PlayClip2D(wrnS);
                    //canwarnsound = false;
                //}
            }
            if (shockamount >= maxshockamount)
            {
                shockamount = 0;
                PMovement plhrt = Pl.gameObject.GetComponent<PMovement>();
                plhrt.shockdamge();
                if (canbuzzsound == true)
                {
                    AudioHelper.PlayClip2D(shckS);
                    canbuzzsound = false;
                }
                shocking = false;
                //Debug.Log("shock");
            }
        }
    }
    void hurt()
    {

    }
}
