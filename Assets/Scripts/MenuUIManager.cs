using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject settingsCanvas;
    public GameObject howToPlayCanvas;
    public GameObject leaderboardCanvas;
    public GameObject exitCanvas;

    //settings UI
    public Slider music;
    public Slider sound;
    public Slider aim;
    void Start()
    {
        menuCanvas.SetActive(true);

        LoadSliders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void OpenHowToPlay()
    {
        howToPlayCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void OpenLeaderboard()
    {
        leaderboardCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void OpenExit()
    {
        exitCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }



    public void EasyDifficulty()
    {
        GameManager.instance.difficulty = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void MediumDifficulty()
    {
        GameManager.instance.difficulty = 1.5f;
        SceneManager.LoadScene(1);
    }

    public void HardDifficulty()
    {
        GameManager.instance.difficulty = 2.0f;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


// settings UI
    public void SetMusic()
    {
        GameManager.instance.audioSource.volume = music.value;
        PlayerPrefs.SetFloat("musicSave", music.value);
    }

    public void SetSound()
    {
        GameManager.instance.soundEffects = sound.value;
        PlayerPrefs.SetFloat("soundSave", sound.value);
    }

    public void SetAim()
    {
        GameManager.instance.aimSensitivity = aim.value;
        PlayerPrefs.SetFloat("aimSave", aim.value);
    }

    public void backToMenu(GameObject currentCanvas)
    {
        currentCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    private void LoadSliders()
    {
        if (PlayerPrefs.HasKey("musicSave"))
        {
            music.value = PlayerPrefs.GetFloat("musicSave");
        }
        else
        {
            music.value = 1;
        }

        if (PlayerPrefs.HasKey("soundSave"))
        {
            sound.value = PlayerPrefs.GetFloat("soundSave");
        }
        else
        {
            sound.value = 1;
        }

        if (PlayerPrefs.HasKey("aimSave"))
        {
            aim.value = PlayerPrefs.GetFloat("aimSave");
        }
        else
        {
            aim.value = 0.5f;
        }
    }


}
