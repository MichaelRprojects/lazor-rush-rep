using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public static bool shtrest = false;
    int mxeshield = 100;
    float eshield = 100;
    float shldlsmlt = 1;
    bool abeshieldloss = false;
    bool beshieldloss = true;
    bool eshieldloss = false;
    public static float Deshield;
    [SerializeField] GameObject shld;
    [SerializeField] GameObject shldv;
    [SerializeField] GameObject pshld;
    [SerializeField] GameObject pshldv;
    [SerializeField] AudioClip ShupS = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PMovement.isdead == false)
        {
            //if (Input.GetKeyD(KeyCode.C))
            //{
                //beshieldloss = true;
            //}
            if (Input.GetKey(KeyCode.C))
            {
                if (Level01Controller.pgpaused == false)
                {
                    //abeshieldloss = true;
                    if (eshield > 0)
                    {
                        DelayHelper.DelayAction(this, beshieldlossf, .25f);
                        eshieldloss = true;
                        if (beshieldloss == false)
                        {
                            shld.SetActive(true);
                            shldv.SetActive(true);
                        }
                        //pshld.SetActive(true);
                        //pshldv.SetActive(true);
                        shtrest = true;
                    }
                }
            }
            if (!Input.GetKey(KeyCode.C))
            {
                if (Level01Controller.pgpaused == false)
                {
                    abeshieldloss = false;
                    beshieldloss = true;
                    eshieldloss = false;
                    shld.SetActive(false);
                    shldv.SetActive(false);
                    pshld.SetActive(false);
                    pshldv.SetActive(false);
                    shtrest = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (Level01Controller.pgpaused == false)
                {
                    if (eshield > 0)
                    {
                        AudioHelper.PlayClip2D(ShupS);
                    }
                }
            }
            if (eshield <= 0)
            {
                shld.SetActive(false);
                shldv.SetActive(false);
                pshld.SetActive(false);
                pshldv.SetActive(false);
            }
            if (abeshieldloss == true)
            {
                //beshieldloss = true;
                //DelayHelper.DelayAction(this, beshieldlossf, .25f);
            }
            if (beshieldloss == true)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        shldlsmlt = 5;
                        pshld.SetActive(true);
                        pshldv.SetActive(true);
                    }
                }
            }
            if (beshieldloss == false)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        shldlsmlt = .25f;
                        pshld.SetActive(false);
                        pshldv.SetActive(false);
                    }
                }
            }
            if (eshieldloss == true)
            {
                if (eshield > 0)
                {
                    eshield = Mathf.Clamp(eshield - (60 * shldlsmlt * Time.deltaTime), 0.0f, mxeshield);
                }
            }
            if (eshieldloss == false)
            {
                if (eshield < mxeshield)
                {
                    eshield = Mathf.Clamp(eshield + (30 * Time.deltaTime), 0.0f, mxeshield);
                }
            }
            Deshield = Mathf.Round(eshield);
        }
    }
    void beshieldlossf ()
    {
        beshieldloss = false;
    }
}
