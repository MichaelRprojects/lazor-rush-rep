using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject YWscrn;
    [SerializeField] Text Timeds;
    [SerializeField] Text killds;
    [SerializeField] AudioClip wnsnd = null;
    public static string minut;
    public static string secon;
    public static float klltl;
    public float thschcknum;
    public static float timenum;
    bool timron = true;
    void Start()
    {
        timenum = 0.0f;
        YWscrn.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plyr")
        {
            timron = false;
            AudioHelper.PlayClip2D(wnsnd);
            Level01Controller.chckpntcntr = thschcknum;
            timsnd();
            timreset();
            klnmsnd();
            klnmreset();
            //string minut = ((int)timenum / 60).ToString();
            //string secon = (timenum % 60).ToString("f2");
            //dfgd
            //string minut = ((int)PlayerPrefs.GetFloat("tstlvtm")/ 60).ToString();
            //string secon = (PlayerPrefs.GetFloat("tstlvtm") % 60).ToString("f2");
            Level01Controller.distim();
            Timeds.text = minut + ":" + secon;
            //killds.text = Level01Controller.currentScore.ToString();
            //killds.text = PlayerPrefs.GetFloat("tstlvklnm").ToString();
            killds.text = klltl.ToString();
            if (Level01Controller.pstbislvc2 == true)
            {
                if(klltl < 60)
                {
                    killds.color = Color.red;
                    killds.text = klltl.ToString() + " You cheated.";
                }
            }
            Level01Controller.unlclev();
            Level01Controller.youwin = true;
            YWscrn.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timron == true)
        {
            timenum += Time.deltaTime;
        }
    }
    public static void timsnd()
    {
        Level01Controller.timerc(timenum, 0f);
    }
    public static void timreset()
    {
        timenum = 0.0f;
    }
    public static void klnmsnd()
    {
        Level01Controller.klnmrc(Level01Controller.currentScore, 0f);
    }
    public static void klnmreset()
    {
        Level01Controller.currentScore = 0;
    }
}
