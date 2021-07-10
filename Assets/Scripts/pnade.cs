using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnade : MonoBehaviour
{
    [SerializeField] GameObject pexp;
    [SerializeField] Light glght;
    public static float lghtnum;
    //Vector3 scaler;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, 5f);
        DelayHelper.DelayAction(this, slfdstrct3, 2f);
        //glght.intensity = 3.5f;
        glght.intensity = Melee.lightamnt;
        //glght.intensity = 5f / Shooting.mclip * (Shooting.clip + 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //glght.intensity = 5f / Shooting.mclip * (Shooting.clip + 1.5f);
        lghtnum = glght.intensity;
    }
    void slfdstrct3()
    {
        //glght.intensity = 3.5f;
        //scaler = new Vector3(Melee.expldamnt * 1.2f +.5f, Melee.expldamnt *1.2f + .5f, Melee.expldamnt *1.2f +.5f);
        GameObject pexpl = Instantiate(pexp, this.transform.position, this.transform.rotation);
        //=scaler
        //pexpl.transform.localScale = Vector3.Lerp(pexpl.transform.localScale, scaler, 10f * Time.deltaTime);
        Destroy(pexpl, .5f);
        Destroy(this.gameObject);
    }
}
