using UnityEngine;

public class PanHeat : MonoBehaviour
{
    private float heatLevel = 0f; // Nivel de calor actual

    public void SetHeatLevel(float level)
    {
        heatLevel = Mathf.Clamp01(level); // Asegurar que est� entre 0 y 1
        UpdateHeatEffect();
    }

    private void UpdateHeatEffect()
    {
        // Aqu� puedes agregar efectos visuales o l�gicos seg�n el nivel de calor
        Debug.Log($"Heat Level: {heatLevel}");

        // Ejemplo: Cambiar el color del material seg�n el calor
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.Lerp(Color.gray, Color.red, heatLevel);
        }
    }

    public float GetHeatLevel()
    {
        return heatLevel; // Permitir que otros scripts consulten el nivel de calor
    }
}
