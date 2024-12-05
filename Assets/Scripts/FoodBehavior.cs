using UnityEngine;
public enum CookingState
{
    raw,
    acceptable,
    negro
}

public class FoodBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private int MAX_COOK_LEVEL = 100;
    public int cook_level = 0;
    public CookingState current_cooking_state = CookingState.raw;

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

    private void VerifyState()
    {
        if (cook_level < 50)
        {
            current_cooking_state = CookingState.raw;
            Debug.Log("anhaa estoy crudo");
        }
        else if (cook_level >= 50 && cook_level < 70)
        {
            current_cooking_state = CookingState.acceptable;
            Debug.Log("anhaa me aceptaron");
        }
        else
        {
            current_cooking_state = CookingState.negro;
            Debug.Log("anhaa me negree");
        }
    }

    private void FixedUpdate()
    {
        // Si el alimento tiene alguna lógica adicional, implementarla aquí
    }

    public void Cook()
    {
        if (cook_level < MAX_COOK_LEVEL)
        {
            cook_level++;
            Debug.Log("anhaa me estoy cocinando");
            VerifyState();
            
        }
    }
}
