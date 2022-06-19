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
        startButton.onClick.AddListener(startGame);
        restartButton.onClick.AddListener(restartGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(startGame);
    }

    private void startGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        startButton.gameObject.SetActive(false);
        titleDisplay.gameObject.SetActive(false);
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void updateScore(int points)
    {
        score += points;
        scoreDisplay.text = "Score:" + score;
    }

    public void objectMissed()
    {
        livesCount--;
        if (livesCount > 0)
        {
            Destroy(lives[livesCount]);
        }
        else
        {
            Destroy(lives[0]);
            gameOver();
        }
    }

    void gameOver()
    {
        gameOverDisplay.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        gunScript.enabled = false;
        poolScript.gameEnder();
    }

}