using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float soundEffects;
    public float aimSensitivity;
    public float difficulty;

    public AudioSource audioSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadPref();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadPref()
    {
        if (PlayerPrefs.HasKey("musicSave"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("musicSave");
        }
        else
        {
            audioSource.volume = 1;
        }

        if (PlayerPrefs.HasKey("soundSave"))
        {
            soundEffects = PlayerPrefs.GetFloat("soundSave");
        }
        else
        {
            soundEffects = 1;
        }

        if (PlayerPrefs.HasKey("aimSave"))
        {
            aimSensitivity = PlayerPrefs.GetFloat("aimSave");
        }
        else
        {
            aimSensitivity = 0.5f;
        }
    }
}


