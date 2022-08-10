using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    AudioSource audioSource;
    //int 1
    public static float sngnum;
    public static bool nlld = true;
    public static float pvol;
    [SerializeField] AudioClip Songa;
    [SerializeField] AudioClip Songb;
    [SerializeField] AudioClip Songc;
    [SerializeField] AudioClip Songd;
    [SerializeField] AudioClip Songe;
    [SerializeField] AudioClip Songf;

    private void Awake()
    {
        #region Singleton Pattern (Simple)
        //if(Instance == null)
        //{
        //Instance = this;
        //DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        //}
        //else
        //{
        //Destroy(gameObject);
        //}
        #endregion
        //Debug.Log(PlayerPrefs.GetFloat("songnum"));
        sngnum = PlayerPrefs.GetFloat("songnum");
        //Debug.Log(sngnum);
        nlld = false;
        //chsesng();
        //float pvolsv = PlayerPrefs.GetFloat("pvol");
        //PlayerPrefs.SetFloat("pvol", pvolsv);
        //PlaySong(Songa);
    }
    public void PlaySong(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    void songcn()
    {
        //audioSource.clip = null;
        //audioSource.clip = Songa;
        //Debug.Log("fuckkk");
        //audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            //Debug.Log("fuckk");
        }
        audioSource.volume = pvol;
        //PlayerPrefs.SetFloat("songnum", sngnum);
        //mmmmmmm
        //float pvolsv = PlayerPrefs.GetFloat("pvol");
        //PlayerPrefs.SetFloat("pvol", pvolsv);
        //pvol = pvolsv;
        //if (sngnum == 1)
        if (PlayerPrefs.GetFloat("songnum") == 1)
        {
            if (Songa != null)
            {
                //PlaySong(Songa);
                if (nlld == false)
                {
                    //audioSource.clip = null;
                    audioSource.Stop();
                    PlaySong(Songa);
                    nlld = true;
                }
                //PlaySong(Songa);
            }
        }
        //if (sngnum == 2)
        if (PlayerPrefs.GetFloat("songnum") == 2)
        {
            if (Songb != null)
            {
                //PlaySong(Songa);
                if (nlld == false)
                {
                    //audioSource.clip = null;
                    audioSource.Stop();
                    PlaySong(Songb);
                    nlld = true;
                }
                //PlaySong(Songb);
                //DelayHelper.DelayAction(this, songcn, 3f);
                //audioSource.clip = Songa;
                //audioSource.Play();
            }
        }
        //if (sngnum == 3)
        if (PlayerPrefs.GetFloat("songnum") == 3)
        {
            if (Songc != null)
            {
                //PlaySong(Songa);
                if (nlld == false)
                {
                    //audioSource.clip = null;
                    audioSource.Stop();
                    PlaySong(Songc);
                    nlld = true;
                }
                //PlaySong(Songc);
            }
        }
        //if (sngnum == 4)
        if (PlayerPrefs.GetFloat("songnum") == 4)
        {
            if (Songd != null)
            {
                //PlaySong(Songa);
                if (nlld == false)
                {
                    //audioSource.clip = null;
                    audioSource.Stop();
                    PlaySong(Songd);
                    nlld = true;
                }
                //PlaySong(Songc);
            }
        }
        //if (sngnum == 5)
        if (PlayerPrefs.GetFloat("songnum") == 5)
        {
            if (Songe != null)
            {
                //PlaySong(Songa);
                if (nlld == false)
                {
                    //audioSource.clip = null;
                    audioSource.Stop();
                    PlaySong(Songe);
                    nlld = true;
                }
                //PlaySong(Songc);
            }
        }
        //if (sngnum == 6)
        if (PlayerPrefs.GetFloat("songnum") == 6)
        {
            if (Songf != null)
            {
                //PlaySong(Songa);
                if (nlld == false)
                {
                    //audioSource.clip = null;
                    audioSource.Stop();
                    PlaySong(Songf);
                    nlld = true;
                }
                //PlaySong(Songc);
            }
        }

    }
    
}
