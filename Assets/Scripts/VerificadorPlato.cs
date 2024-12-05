using UnityEngine;

public class VerificadorPlato : MonoBehaviour
{
    public Plato plato;  // Referencia al script Plato

    // Método para verificar el plato
    private void Update()
    {
        if (plato != null)
        {
            // Llama a VerificarPlato() para verificar si el plato está listo
            plato.VerificarPlato();
        }
    }
}
