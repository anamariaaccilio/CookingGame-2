using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ContentSizeFitter;

public enum GameMode { Tutorial, TimeTrial }
public enum Recipe { BistecPobre, Spaghetti}
public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;
    public GameMode currentMode;
    public Recipe currentRecipe;
    public GameObject tutorialObjects;
    public GameObject timeTrialObjects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional, for cross-scene persistence
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneTransitionManager.singleton.GetMode() == SceneTransitionManager.GameMode.Tutorial)
        {
            // Enable tutorial pop-ups
            SetGameMode(GameMode.Tutorial);
            timeTrialObjects.SetActive(false);
            tutorialObjects.SetActive(true);
        }
        else if (SceneTransitionManager.singleton.GetMode() == SceneTransitionManager.GameMode.TimeTrial)
        {
            // Start the timer and gameplay
            SetGameMode(GameMode.TimeTrial);
            timeTrialObjects.SetActive(true);
            tutorialObjects.SetActive(false);
        }
    }

    public void SetGameMode(GameMode mode)
    {
        currentMode = mode;
    }
    public void SetRecipe(Recipe recipe)
    {
        currentRecipe = recipe;
    }
}

