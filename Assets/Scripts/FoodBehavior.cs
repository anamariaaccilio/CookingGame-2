using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pan"))
        {
            Debug.Log("Alimento tocó la sartén");
        }
    }

    private void FixedUpdate()
    {
        // Si el alimento tiene alguna lógica adicional, implementarla aquí
    }
}
