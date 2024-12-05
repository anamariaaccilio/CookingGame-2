using UnityEngine;

public class PanController : MonoBehaviour
{
    [Header("Trigger Collider for Food Detection")]
    public Collider triggerCollider;

    [Header("Physics Settings")]
    public float attractionForce = 10f; // Fuerza para mantener los alimentos dentro
    public float maxFoodSpeed = 5f;    // Velocidad máxima permitida para los alimentos
    public float heightLimit = 0.2f;  // Altura máxima del alimento desde la sartén

    private void FixedUpdate()
    {
        // Encuentra todos los alimentos dentro del trigger
        Collider[] foods = Physics.OverlapBox(triggerCollider.bounds.center, triggerCollider.bounds.extents, triggerCollider.transform.rotation, LayerMask.GetMask("Food"));
        foreach (var food in foods)
        {
            Rigidbody foodRb = food.GetComponent<Rigidbody>();
            if (foodRb != null)
            {
                // Aplica una fuerza hacia el centro de la sartén
                Vector3 directionToCenter = triggerCollider.bounds.center - food.transform.position;
                foodRb.AddForce(directionToCenter.normalized * attractionForce);

                // Limitar la velocidad del alimento
                if (foodRb.velocity.magnitude > maxFoodSpeed)
                {
                    foodRb.velocity = foodRb.velocity.normalized * maxFoodSpeed;
                }

                // Limitar la altura del alimento
                if (food.transform.position.y > triggerCollider.bounds.center.y + heightLimit)
                {
                    food.transform.position = new Vector3(
                        food.transform.position.x,
                        triggerCollider.bounds.center.y + heightLimit,
                        food.transform.position.z
                    );
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (triggerCollider != null)
        {
            Gizmos.color = Color.green; // Cambia el color si necesitas distinguirlo
            Gizmos.DrawWireCube(triggerCollider.bounds.center, triggerCollider.bounds.size);
        }
    }
}
