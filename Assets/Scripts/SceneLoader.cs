using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        //PlayerPrefs.SetFloat("songnum", 1);
        if (sceneName == "Level01")
        {
            PlayerPrefs.SetFloat("songnum", 2);
        }
        SceneManager.LoadScene(sceneName);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
