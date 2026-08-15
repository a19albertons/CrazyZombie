using UnityEngine;

/// <summary>
/// Clase que gestiona los enemigos muertos y el patrón singleton del GameManager.
/// </summary>
public class GameManager : MonoBehaviour
{

    /// Instancia del GameManager para el patrón singleton
    public static GameManager instance; // Instancia del GameManager para el patron singleton

    private int muertos = 0; // Variable para almacenar el número de enemigos muertos se inicializa a 0

    /// <summary>
    /// Se ejecuta al crear el objeto GameManager, si no hay ninguna instancia de GameManager, se asigna la instancia actual a la variable instance.
    /// </summary>
    void Awake()
    {
        // Implementación del patrón singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el GameManager se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruye cualquier instancia adicional del GameManager
        }
    }

    /// <summary>
    /// Incrementa el contador de enemigos muertos en 1. Se llama cada vez que un enemigo es eliminado.
    /// </summary>
    public void IncrementarMuertos()
    {
        muertos++; // Incrementa el contador de enemigos muertos
    }

    /// <summary>
    /// Devuelve el número de enemigos muertos. Se puede utilizar para mostrar estadísticas o para otros propósitos en el juego.
    /// </summary>
    /// <returns>Devuelve un int con el número de enemigos muertos registrados</returns>
    public int GetMuertos()
    {
        return muertos; // Devuelve el número de enemigos muertos
    }

    /// <summary>
    /// Reinicia el contador de enemigos muertos a 0. Se puede utilizar al reiniciar el juego o al comenzar una nueva partida.
    /// </summary>
    public void ResetMuertos()
    {
        muertos = 0; // Reinicia el contador de enemigos muertos a 0
    }

}
