using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject newGameMenu;
    public GameObject scoreboard;
    public GameObject settings;
    public GameObject credits;
    public GameObject newGameAlert;
    public GameObject exitGameAlert;
    public GameObject deleteScoreboardAlert;

    [Header("Main Menu Buttons")]
    public Button newGameButton;
    public Button startButton;
    public Button settingsButton;
    public Button scoreboardButton;
    public Button creditsButton;
    public Button exitButton;

    [Header("Game Menu Settings")]
    public TMPro.TMP_Dropdown gameModeDropdown;
    public Button newGameAlertButton;
    public Button exitGameAlertYesButton;
    public Button exitGameAlertNoButton;
    public Button deleteScoreboardButton;
    public Button deleteScoreboardYesAlert;
    public Button deleteScoreboardNoAlert;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        newGameButton.onClick.AddListener(EnableNewGame);
        scoreboardButton.onClick.AddListener(EnableScoreboard);
        settingsButton.onClick.AddListener(EnableSettings);
        creditsButton.onClick.AddListener(EnableCredits);
        exitButton.onClick.AddListener(EnableExitGameAlert);
        deleteScoreboardButton.onClick.AddListener(EnableScoreboardDeleteAlert);



        newGameAlertButton.onClick.AddListener(DisableNewGameAlert);
        exitGameAlertYesButton.onClick.AddListener(ExitGame);
        exitGameAlertNoButton.onClick.AddListener(DisableExitGameAlert);
        deleteScoreboardNoAlert.onClick.AddListener(DisableScoreboardDeleteAlert);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void StartGame()
    {
        if (SceneTransitionManager.singleton.currentRecipe != SceneTransitionManager.Recipe.None)
        {
            HideAll();
            if (gameModeDropdown.options[gameModeDropdown.value].text == "Tutorial")
            {
                SceneTransitionManager.singleton.SetGameMode(SceneTransitionManager.GameMode.Tutorial);
            }
            else
            {
                SceneTransitionManager.singleton.SetGameMode(SceneTransitionManager.GameMode.TimeTrial);
            }
                SceneTransitionManager.singleton.GoToSceneAsync(1);
        }
        else
        {
            EnableNewGameAlert();
        }

    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableNewGame()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableNewGameAlert()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);
        newGameAlert.SetActive(true);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableSettings()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(true);
        scoreboard.SetActive(false);
        deleteScoreboardAlert.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableScoreboard()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(true);
        credits.SetActive(false);
    }
    public void EnableCredits()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(true);
    }
    public void DisableNewGameAlert()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);
        newGameAlert.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableExitGameAlert()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        exitGameAlert.SetActive(true);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void DisableExitGameAlert()
    {
        mainMenu.SetActive(true);
        newGameMenu.SetActive(false);
        exitGameAlert.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableScoreboardDeleteAlert() {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(true);
        deleteScoreboardAlert.SetActive(true);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void DisableScoreboardDeleteAlert()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(true);
        deleteScoreboardAlert.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
}
