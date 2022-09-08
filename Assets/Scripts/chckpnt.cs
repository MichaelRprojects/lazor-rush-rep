using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chckpnt : MonoBehaviour
{
    // Start is called before the first frame update
    //Transform Pl;
    //[SerializeField] GameObject chcksvdnt;
    public float thschcknum;
    [SerializeField] AudioClip chckpsnd = null;
    void Start()
    {
        //Pl = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plyr")
        {
            Level01Controller.chckpntcntr = thschcknum;
            AudioHelper.PlayClip2D(chckpsnd);
            Timer.timsnd();
            Timer.timreset();
            Timer.klnmsnd();
            Timer.klnmreset();
            //chcksvdnt.SetActive(true);
            //DelayHelper.DelayAction(this, rmvchcknt, 2f);
            Level01Controller.offchcknt = false;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //public void rmvchcknt()
    //{
        //chcksvdnt.SetActive(false);
    //}
}
