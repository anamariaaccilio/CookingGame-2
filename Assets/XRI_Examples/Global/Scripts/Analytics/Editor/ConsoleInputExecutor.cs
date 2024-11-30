using UnityEngine;
using UnityEditor;

public class ConsoleInputExecutor : EditorWindow
{
    private string inputCommand = "";

    [MenuItem("Window/Console Input Executor")]
    public static void ShowWindow()
    {
        GetWindow<ConsoleInputExecutor>("Console Executor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Execute Command", EditorStyles.boldLabel);

        inputCommand = EditorGUILayout.TextField("AddPlayerInScoreboard", inputCommand);

        if (GUILayout.Button("Execute"))
        {
            ExecuteCommand(inputCommand);
        }
    }

    private void ExecuteCommand(string command)
    {
        if (string.IsNullOrEmpty(command)) return;

        try
        {
            // Example: You can replace this with your logic
            var scoreboard = GameObject.Find("Scoreboard")?.GetComponent<Scoreboard>();
            if (scoreboard != null)
            {
                var parts = command.Split(',');
                scoreboard.AddScoreFromConsole(parts[0], int.Parse(parts[1]));
                Debug.Log($"Executed: {command}");
            }
            else
            {
                Debug.LogError("Scoreboard not found!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error executing command: {ex.Message}");
        }
    }
}
