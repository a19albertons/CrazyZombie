using UnityEngine;

/// <summary>
/// Clase AudioManager: Se encarga de reproducir la música de fondo del juego
/// Exige que el GameObject tenga un componente AudioSource para reproducir la música de fondo.
/// </summary>
[RequireComponent(typeof(AudioSource))] // Obliga a tener un componente Audio Source al tener este script para reproducir los clips de audio correspondientes
public class AudioManager : MonoBehaviour
{


    [SerializeField]
    AudioClip BackgroundMusic; // Componente de audio para reproducir la música de fondo
    AudioSource audioSource;

    static AudioManager instance;

    /// <summary>
    /// Se ejecuta al iniciar el patron singleton, si no hay ninguna instancia de AudioManager, se crea una nueva instancia y se asigna a la variable instance.
    /// Si ya existe una instancia, se destruye el objeto actual para evitar duplicados.
    /// </summary>
    void Start()
    {
        // Obtenemos el componente AudioSource para su posterior uso
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = true; // Configura el AudioSource para que se reproduzca en bucle
        audioSource.clip = BackgroundMusic; // Asigna la música de fondo al AudioSource
        audioSource.Play(); // Inicia la reproducción del audio
    }

    /// <summary>
    /// Se ejecuta al crear el objeto AudioManager, si no hay ninguna instancia de AudioManager, se asigna la instancia actual a la variable instance.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el AudioManager se destruya al cambiar de escena
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destruye cualquier instancia adicional del AudioManager
        }

    }
}
