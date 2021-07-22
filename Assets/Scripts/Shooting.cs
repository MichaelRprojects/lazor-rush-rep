using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Camera cameracontroller;
    [SerializeField] Transform rayorigin;
    // 2 had sf
    float shootDistance = 20f;
    int weaponDamage = 50;
    [SerializeField] GameObject tester;

    public static float Pshootdis;

    [SerializeField] GameObject pprojectile;

    [SerializeField] GameObject mflr;
    [SerializeField] AudioClip gnf = null;
    [SerializeField] AudioClip RlS = null;
    [SerializeField] AudioClip MtS = null;
    [SerializeField] AudioClip GnclS = null;
    [SerializeField] Light rlight;
    float lintsi = 3.5f;

    //public static GameObject hitsp;

    [SerializeField] LayerMask Grounded;
    public static int clip = 6;
    public static int mclip = 6;
    bool shoota = true;
    bool reloada = false;
    bool clcka = true;
    //bool setcl0a = false;
    //bool setcl6a = false;

    [SerializeField] GameObject gno;
    [SerializeField] Transform hpsn;
    [SerializeField] Transform adspn;
    bool reloading = false;
    public static bool preloading = false;


    RaycastHit objectHit;
    // Start is called before the first frame update
    void Start()
    {
        clip = 6;
        //lintsi = lintsi / mclip * (clip + 1.5f);
        lintsi = lintsi + 1.5f;
        rlight.intensity = lintsi;
        reloada = false;
        reloading = false;
        preloading = false;

        Pshootdis = shootDistance;
    }

    // Update is called once per frame
    private void Update()
    {
        if (PMovement.isdead == false)
        {

            if (clip <= 0)
            {
                shoota = false;
            }
            if (clip <mclip && shoota == true)
            {
                reloada = true;
            }
            if (Melee.shootatr == true && reloading == false)
            {
                if (clip > 0)
                {
                    shoota = true;
                }
            }
            //if (Melee.gunua == true)
            //{
                //setcl0a = true;
            //}
            //if(setcl0a == true)
            //{
                //clip = 0;
                //setcl0a = false;
            //}
            //if (Melee.gunua == false)
            //{
                //clip = 6;
            //}
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Level01Controller.pgpaused == false)
                {
                    if (clip == 0 && clcka == true)
                    {
                        //Melee.gunua == false
                        if (Melee.shtrest == false)
                        {
                            AudioHelper.PlayClip2D(GnclS);
                        }
                    }
                    if (clip > 0)
                    {
                        if (shoota == true)
                        {
                            if (Melee.shtrest == false)
                            {
                                clip -= 1;
                            }
                        }
                    }
                    if (shoota == true)
                    {
                        if (Melee.shtrest == false)
                        {
                            shoot();
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (Level01Controller.pgpaused == false)
                {
                    if (reloading == false && PMovement.pissprnt == false && Melee.shtrest == false && Melee.gunua == false)
                    {
                        gno.transform.position = Vector3.Lerp(gno.transform.position, adspn.position, Time.deltaTime * 20f);
                        if (cameracontroller.fieldOfView > 53)
                        {
                            cameracontroller.fieldOfView -= (30 * Time.deltaTime);
                        }
                    }
                    if (reloading == true || PMovement.pissprnt == true || Melee.shtrest == true || Melee.gunua == true)
                    {
                        if (cameracontroller.fieldOfView < 60)
                        {
                            cameracontroller.fieldOfView += (30 * Time.deltaTime);
                        }
                        gno.transform.position = Vector3.Lerp(gno.transform.position, hpsn.position, Time.deltaTime * 20f);
                    }
                }
            }
            if (!Input.GetKey(KeyCode.Mouse1))
            {
                if (cameracontroller.fieldOfView < 60)
                {
                    cameracontroller.fieldOfView += (30 * Time.deltaTime);
                }
                gno.transform.position = Vector3.Lerp(gno.transform.position, hpsn.position, Time.deltaTime * 20f);
            }

            preloading = reloading;

            if (reloada == true)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (clip < mclip)
                        {
                            if (Melee.gunua == false)
                            {
                                shoota = false;
                                reloada = false;
                                clcka = false;
                                reloading = true;
                                DelayHelper.DelayAction(this, shootat, 1f);
                            }
                        }
                    }
                }
            }

        }
    }
    void shoot()
    {
        Vector3 rayDirection = cameracontroller.transform.forward;
        Debug.DrawRay(rayorigin.position, rayDirection * shootDistance, Color.blue, 1f);

        mflr.SetActive(true);
        AudioHelper.PlayClip2D(gnf);
        DelayHelper.DelayAction(this, endf, .1f);
        rlight.intensity = lintsi / mclip * (clip + 1.5f);

        Vector3 eposp = rayorigin.transform.position;
        Vector3 edirp = cameracontroller.transform.forward;
        Quaternion erotp = cameracontroller.transform.rotation;
        Vector3 ebspnp = eposp + edirp * 1.1f;
        Rigidbody rbpb = Instantiate(pprojectile, ebspnp, erotp).GetComponent<Rigidbody>();
        //32
        rbpb.AddForce(rayorigin.transform.forward * 90f, ForceMode.Impulse);

        Pshootdis = shootDistance;
        //if (Vector3.Distance(rayorigin.transform.position, rbpb.transform.position) > 3f)
        //{
            //Destroy(rbpb);
            //GameObject rbpbo = rbpb;
            //Destroy(rbpb.gameObject);
        //}

        //if (Physics.Raycast(cameracontroller.transform.position, rayDirection, out objectHit, shootDistance, Grounded))
        if (Physics.Raycast(rayorigin.position, rayDirection, out objectHit, shootDistance, Grounded))
        {
            tester.SetActive(true);
            tester.transform.position = objectHit.point;
            //hitsp.transform.position = tester.transform.position;

            Pshootdis = Vector3.Distance(rayorigin.position, objectHit.point);

            DelayHelper.DelayAction(this, pMtS, .1f);

            DelayHelper.DelayAction(this, endt, .1f);
            if (objectHit.transform.tag == "Enemyt")
            {
                EnemyS enemyS = objectHit.transform.gameObject.GetComponent<EnemyS>();
                if (enemyS != null)
                {
                    enemyS.TDamage(weaponDamage);
                }
                EnemySb enemySb = objectHit.transform.gameObject.GetComponent<EnemySb>();
                if (enemySb != null)
                {
                    enemySb.TDamage(weaponDamage);
                }
            }
            if (objectHit.transform.tag == "shootablee")
            {
                Mine mine = objectHit.transform.gameObject.GetComponent<Mine>();
                if (mine != null)
                {
                    mine.explodemn();
                }
            }
        }
    }
    void shootat()
    {
        clip = mclip;
        rlight.intensity = lintsi / mclip * (clip + 1.5f);
        AudioHelper.PlayClip2D(RlS);
        shoota = true;
        reloada = true;
        clcka = true;
        reloading = false;
    }
    void endf()
    {
        //if (mflr.activeSelf)
        //{
            mflr.SetActive(false); ;
        //}
    }
    void endt()
    {
        //if (mflr.activeSelf)
        //{
        tester.SetActive(false); ;
        //}
    }
    void pMtS()
    {
        AudioHelper.PlayClip2D(MtS);
    }

}
