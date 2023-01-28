using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroywall : MonoBehaviour
{
    public int goalnum;
    [SerializeField] AudioClip WllexplS = null;
    [SerializeField] GameObject wlleexpl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Level01Controller.currentScore == goalnum)
        {
            DelayHelper.DelayAction(this, wallbreak, 1f);
        }
    }
    public void wallbreak()
    {
        GameObject wllexpld = Instantiate(wlleexpl, this.transform.position, this.transform.rotation);
        Destroy(wllexpld, .5f);
        AudioHelper.PlayClip2D(WllexplS);
        Destroy(this.gameObject);
    }
}
