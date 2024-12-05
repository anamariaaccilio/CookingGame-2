using UnityEngine;

public class StoveHeatZone : MonoBehaviour
{
    [SerializeField] private StoveManager stoveManager; // Referencia al manager del stove
    [SerializeField] private int stoveIndex; // Índice del stove en la lista del manager
    [SerializeField] private Collider heatZoneCollider; // Collider de la zona de calor, asignable desde el editor
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("estoy adentro aaa");

        if (heatZoneCollider != null)
        {
            Debug.Log("esta wbd no es null");
        }
        Debug.Log(other.tag);
        Debug.Log(other.name);


        // Verificar si el objeto entrante es una sartén y si está dentro del collider asignado
        if (heatZoneCollider != null && other.name == "Pan")
        {

            Debug.Log("pan entro");
            PanHeat pan = other.GetComponent<PanHeat>();
            if (pan != null)
            {

                Debug.Log("pan no es null");
                // Pasar el nivel de calor actual al script de la sartén
                float heatLevel = stoveManager.GetHeatLevel(stoveIndex);
                pan.SetHeatLevel(heatLevel);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Verificar si el objeto está dentro del collider asignado
        if (heatZoneCollider != null && other.CompareTag("Pan"))
        {
            PanHeat pan = other.GetComponent<PanHeat>();
            if (pan != null)
            {
                // Actualizar el nivel de calor mientras la sartén está en la zona
                float heatLevel = stoveManager.GetHeatLevel(stoveIndex);
                pan.SetHeatLevel(heatLevel);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Restablecer el nivel de calor cuando la sartén sale de la zona y está dentro del collider
        if (heatZoneCollider != null && other.CompareTag("Pan"))
        {
            PanHeat pan = other.GetComponent<PanHeat>();
            if (pan != null)
            {
                pan.SetHeatLevel(0f); // Sin calor fuera del fuego
            }
        }
    }
}
