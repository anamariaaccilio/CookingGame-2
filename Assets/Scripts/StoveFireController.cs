using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Content.Interaction;

public class StoveManager : MonoBehaviour
{
    [System.Serializable]
    public class Stove
    {
        public XRKnob fireKnob; // Dial que controla el fuego
        public ParticleSystem fireParticles; // Sistema de partículas del fuego
        public AudioSource fireAudio; // (Opcional) Audio del fuego
    }

    [SerializeField]
    private List<Stove> stoves = new List<Stove>(); // Lista de stoves

    void Start()
    {
        foreach (var stove in stoves)
        {
            if (stove.fireKnob != null)
            {
                // Vincular el evento del knob a la función que actualiza el fuego
                stove.fireKnob.onValueChange.AddListener(value => UpdateFireIntensity(stove, value));
            }
        }
    }

    private void UpdateFireIntensity(Stove stove, float value)
    {
        float fireIntensity = value < 0.5f
        ? Mathf.Lerp(0.2f, 1f, value * 2) // Escala entre 0.2 y 1 para valores [0, 0.5]
        : Mathf.Lerp(1f, 0f, (value - 0.5f) * 2); // Escala entre 1 y 0 para valores [0.5, 1]

        if (stove.fireParticles != null)
        {
            // Ajustar la tasa de emisión de partículas
            var emissionModule = stove.fireParticles.emission;
            emissionModule.rateOverTime = Mathf.Lerp(0, 50, fireIntensity); // Ajusta el 50 según intensidad máxima deseada

            // Ajustar el tamaño de las partículas
            var mainModule = stove.fireParticles.main;
            mainModule.startLifetime = Mathf.Lerp(0.1f, 1f, fireIntensity); // Ajusta los valores según necesidad
        }

        if (stove.fireAudio != null)
        {
            // Ajustar el volumen del sonido del fuego
            stove.fireAudio.volume = fireIntensity; // Volumen sigue la intensidad del fuego
        }
    }
    public float GetHeatLevel(int stoveIndex)
    {
        if (stoveIndex >= 0 && stoveIndex < stoves.Count)
        {
            // Retorna el nivel de calor según el estado del fuego
            return stoves[stoveIndex].fireKnob.value; // Devuelve el valor del dial (0 a 1)
        }
        return 0f;
    }


}
