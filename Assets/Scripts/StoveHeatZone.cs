using UnityEngine;

public class StoveHeatZone : MonoBehaviour
{
    [SerializeField] private StoveManager stoveManager; // Referencia al manager del stove
    [SerializeField] private int stoveIndex; // Índice del stove en la lista del manager

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto entrante es una sartén
        if (other.CompareTag("Pan"))
        {
            PanHeat pan = other.GetComponent<PanHeat>();
            if (pan != null)
            {
                // Pasar el nivel de calor actual al script de la sartén
                float heatLevel = stoveManager.GetHeatLevel(stoveIndex);
                pan.SetHeatLevel(heatLevel);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Actualizar el nivel de calor mientras la sartén está en la zona
        if (other.CompareTag("Pan"))
        {
            PanHeat pan = other.GetComponent<PanHeat>();
            if (pan != null)
            {
                float heatLevel = stoveManager.GetHeatLevel(stoveIndex);
                pan.SetHeatLevel(heatLevel);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Restablecer el nivel de calor cuando la sartén sale de la zona
        if (other.CompareTag("Pan"))
        {
            PanHeat pan = other.GetComponent<PanHeat>();
            if (pan != null)
            {
                pan.SetHeatLevel(0f); // Sin calor fuera del fuego
            }
        }
    }
}
