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
    private float MAX_COOK_LEVEL = 100f;
    public float cook_level = 0f;
    public CookingState current_cooking_state = CookingState.raw;

    private AudioSource audioSource;  // Referencia al AudioSource
    public AudioClip cookingSound;   // Sonido de cocci�n

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();  // Obtiene el componente AudioSource
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pan"))
        {
            Debug.Log("Alimento toc� la sart�n");
        }
    }

    private void VerifyState()
    {
        if (cook_level < 30f)
        {
            current_cooking_state = CookingState.raw;
            Debug.Log("anhaa estoy crudo");
        }
        else if (cook_level >= 30f && cook_level < 75f)
        {
            current_cooking_state = CookingState.acceptable;
            Debug.Log("anhaa me aceptaron");

            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                // Carne cocida: de un color carne m�s claro, menos amarillo, hacia un marr�n claro.
                renderer.material.color = Color.Lerp(new Color(0.8f, 0.5f, 0.3f), new Color(0.7f, 0.4f, 0.2f), (cook_level - 30f) / 45f);
            }
        }
        else
        {
            current_cooking_state = CookingState.negro;
            Debug.Log("anhaa me negree");

            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                // Carne quemada: de marr�n oscuro a negro
                renderer.material.color = Color.Lerp(new Color(0.5f, 0.25f, 0f), Color.black, (cook_level - 75f) / 25f);
            }
        }
    }

    private void FixedUpdate()
    {
        // L�gica adicional si es necesario
    }

    public void Cook()
    {
        if (cook_level < MAX_COOK_LEVEL)
        {
            cook_level += 0.1f;
            Debug.Log("anhaa me estoy cocinando");
            VerifyState();

            // Reproducir sonido solo cuando el nivel de cocci�n aumenta
            if (audioSource != null && !audioSource.isPlaying)  // Verifica si el sonido no se est� reproduciendo ya
            {
                audioSource.clip = cookingSound;  // Asigna el clip de sonido de cocci�n
                audioSource.Play();  // Reproduce el sonido
            }
        }
        // Add Sound when it reaches a certain level or state if needed
    }
}
