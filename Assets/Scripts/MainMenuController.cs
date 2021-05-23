using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip startSong;
    [SerializeField] Text highScoreTextView;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTextView.text = highScore.ToString();
        if(startSong != null)
        {
            AudioManager.Instance.PlaySong(startSong);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void exitg()
    {
        Application.Quit();
    }
}
