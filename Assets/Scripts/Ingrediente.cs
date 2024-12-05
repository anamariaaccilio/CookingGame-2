using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public enum TipoIngrediente { Tomate, Queso, Pan }

    public TipoIngrediente tipoIngrediente;  // Tipo de ingrediente
    private float peso;  // Peso del ingrediente

    private void Start()
    {
        // Asignamos el peso del ingrediente
        switch (tipoIngrediente)
        {
            case TipoIngrediente.Tomate:
                peso = 0.5f;  // Peso del tomate
                break;
            case TipoIngrediente.Queso:
                peso = 0.3f;  // Peso del queso
                break;
            case TipoIngrediente.Pan:
                peso = 0.2f;  // Peso del pan
                break;
            default:
                peso = 0f;  // Peso predeterminado
                break;
        }
    }

    // Cuando el ingrediente toca el plato
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plato"))  // Si el ingrediente toca el plato
        {
            Plato plato = other.GetComponent<Plato>();  // Obtener el script del plato
            if (plato != null)
            {
                plato.AñadirIngrediente(peso);  // Añadir el peso del ingrediente al plato
                // Convertir el ingrediente en hijo del plato para que no se caiga
                transform.SetParent(plato.transform);
                // Desactivar la gravedad temporalmente
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }
                Debug.Log("Ingrediente añadido: " + tipoIngrediente + " con peso: " + peso);
            }
        }
    }
}
