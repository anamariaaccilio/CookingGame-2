using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plato : MonoBehaviour
{
    public float pesoEsperado = 1.0f;  // Peso total esperado para que el plato est� listo
    private float pesoTotal = 0f;  // Peso actual del plato
    private Renderer platoRenderer;
    public Text mensajeText;  // Referencia al texto del UI

    private void Start()
    {
        // Obtener el Renderer para poder cambiar el color del plato
        platoRenderer = GetComponent<Renderer>();
    }

    public void A�adirIngrediente(float peso)
    {
        pesoTotal += peso;  // Sumar el peso del ingrediente al peso total
        Debug.Log("Peso total en el plato: " + pesoTotal);
        VerificarPlato();  // Verificar si el plato est� listo
    }

    // Cambiar el modificador de acceso a public para que sea accesible
    public void VerificarPlato()
    {
        if (pesoTotal >= pesoEsperado)
        {
            // El plato est� listo, cambiar color a verde
            platoRenderer.material.color = Color.green;

            if (mensajeText != null)
            {
                mensajeText.text = "�Felicidades! El plato est� listo.";
                mensajeText.color = Color.green;
            }
        }
        else
        {
            // El plato no est� listo, cambiar color a rojo
            platoRenderer.material.color = Color.red;

            if (mensajeText != null)
            {
                mensajeText.text = "El plato no est� listo. Faltan ingredientes o el peso es incorrecto.";
                mensajeText.color = Color.red;
            }
        }
    }
}
