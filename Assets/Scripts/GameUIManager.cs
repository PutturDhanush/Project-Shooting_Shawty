using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public int score;

    public TextMeshProUGUI gameOverDisplay;
    public TextMeshProUGUI titleDisplay;

    public Button startButton;
    public Button restartButton;
    public Button mainMenu;

    private CameraMovement cameraScript;
    private Gun gunScript;
    private ObjectPool poolScript;

    public RawImage[] lives = new RawImage[3];
    public int livesCount = 3;

    void Awake()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
        mainMenu.onClick.AddListener(ReturnToMenu);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        startButton.gameObject.SetActive(false);
        titleDisplay.gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ReturnToMenu()
    {
        //add scene change
    }

    void Start()
    {
        cameraScript = GameObject.Find("PlayerSystem").GetComponent<CameraMovement>();
        gunScript = GameObject.Find("Gun").GetComponent<Gun>();
        poolScript = GameObject.Find("Object Pooler").GetComponent<ObjectPool>();

        for (int i = 0; i < 3; i++)
        {
            lives[i].gameObject.SetActive(true);
        }
        scoreDisplay.text = "Score:" + score;
        gameOverDisplay.gameObject.SetActive(false);
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreDisplay.text = "Score:" + score;
    }

    public void ObjectMissed()
    {
        livesCount--;
        if (livesCount > 0)
        {
            Destroy(lives[livesCount]);
        }
        else
        {
            Destroy(lives[0]);
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverDisplay.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        gunScript.enabled = false;
        poolScript.GameEnder();
    }

}
