using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eexplod : MonoBehaviour
{
    Vector3 exscaler;
    [SerializeField] AudioClip escexpl = null;
    // Start is called before the first frame update
    void Start()
    {
        AudioHelper.PlayClip2D(escexpl);
    }

    // Update is called once per frame
    void Update()
    {
        exscaler = new Vector3(20, 20, 20);
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, exscaler, 20f * Time.deltaTime);
    }
}
