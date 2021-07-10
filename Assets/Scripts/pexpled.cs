using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pexpled : MonoBehaviour
{
    Vector3 scaler;
    [SerializeField] AudioClip scexpl = null;
    // Start is called before the first frame update
    void Start()
    {
        AudioHelper.PlayClip2D(scexpl);
    }

    // Update is called once per frame
    void Update()
    {
        scaler = new Vector3(Melee.expldamnt * 1.2f + .5f, Melee.expldamnt * 1.2f + .5f, Melee.expldamnt * 1.2f + .5f);
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, scaler, 20f * Time.deltaTime);
    }
}
