using UnityEngine;
using TMPro; // TextMesh Pro namespace
using System.Linq;  // Import LINQ for OrderByDescending
using System.Collections.Generic;

public class Scoreboard : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI scoreboardText; // Change to TextMeshProUGUI

    [Header("Settings")]
    public int maxEntries = 10; // Limit to 10 scores

    private List<ScoreboardEntry> scoreboardEntries = new List<ScoreboardEntry>();
    private const string SaveKey = "Scoreboard";

    void Start()
    {
        LoadScoreboard();
        UpdateScoreboardUI();
    }

    public void ResetScores()
    {
        // Clear the local scoreboard list
        scoreboardEntries.Clear();

        // Clear the saved data in PlayerPrefs
        PlayerPrefs.DeleteKey(SaveKey);
        PlayerPrefs.Save();

        // Update the UI
        UpdateScoreboardUI();

        Debug.Log("Scoreboard reset successfully.");
    }

    // Add score from console by providing playerName and score
    public void AddScoreFromConsole(string playerName, int score)
    {
        // Add the new score
        scoreboardEntries.Add(new ScoreboardEntry(playerName, score));

        // Sort by score (highest first) and trim to maxEntries
        scoreboardEntries = scoreboardEntries.OrderByDescending(x => x.score).Take(maxEntries).ToList();

        SaveScoreboard();
        UpdateScoreboardUI();
    }

    private void SaveScoreboard()
    {
        string json = JsonUtility.ToJson(new ScoreboardWrapper(scoreboardEntries));
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    private void LoadScoreboard()
    {
        string json = PlayerPrefs.GetString(SaveKey, "{}");
        scoreboardEntries = JsonUtility.FromJson<ScoreboardWrapper>(json)?.entries ?? new List<ScoreboardEntry>();
    }

    private void UpdateScoreboardUI()
    {
        if (scoreboardText != null)
        {
            scoreboardText.text = "Player\t\tScore\n";
            int rank = 1;
            foreach (var entry in scoreboardEntries)
            {
                scoreboardText.text += $"{rank}. {entry.playerName}\t\t{entry.score}\n";
                rank++;
            }
        }
    }

    [System.Serializable]
    private class ScoreboardWrapper
    {
        public List<ScoreboardEntry> entries;

        public ScoreboardWrapper(List<ScoreboardEntry> entries)
        {
            this.entries = entries;
        }
    }
}

[System.Serializable]
public class ScoreboardEntry
{
    public string playerName;
    public int score;

    public ScoreboardEntry(string name, int score)
    {
        playerName = name;
        this.score = score;
    }
}
