using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;
    public Button backButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    [Header("Text")]
    public Text livesText;
    public Text scoreText;
    public Text volSliderText;

    [Header("Slider")]
    public Slider volSlider;



    public void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(() => StartGame());

        if (settingsButton)
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());

        if (backButton)
            backButton.onClick.AddListener(() => ShowMainMenu());

        if (volSlider && volSliderText)
        {
            volSlider.onValueChanged.AddListener((value) => OnSliderValueChange(value));
            volSliderText.text = volSlider.value.ToString();
        }

        if (livesText)
            GameManager.instance.onLifeValueChange.AddListener((value) => OnLifeValueChange(value));

        if (scoreText)
            GameManager.instance.onScoreValueChange.AddListener((value) => OnScoreValueChange(value));
    }

    void OnSliderValueChange(float value)
    {
        if (volSliderText)
            volSliderText.text = value.ToString();
    }

    void OnLifeValueChange(int value)
    {
        livesText.text = value.ToString();
    }

    void OnScoreValueChange(int value)
    {
        scoreText.text = value.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);

                if (pauseMenu.activeSelf)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1.0f;
                }
            }
        }
    }
}
