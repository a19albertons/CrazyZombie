using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase PanelMuerte: Se encarga de mostrar y gestionar el panel de la muerte del jugador con una escena propia
/// </summary>
public class PanelMuerte : MonoBehaviour
{
    [SerializeField]
    TMP_Text textoMuertos; // Referencia al texto dinámico de los que has matado

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor para que se vea al morir y poder interactuar con los botones del panel de muerte
        Cursor.visible = true; // Hace visible el cursor para poder interactuar con los botones del panel de muerte
        textoMuertos.text = "Has muerto, pero has logrado matar: " + GameManager.instance.GetMuertos() + " enemigos"; // Se muestra el texto dinámico con el número de enemigos muertos
    }

    /// <summary>
    /// Función para reiniciar el juego. Se llama al hacer clic en el botón de reiniciar en el panel de muerte.
    /// </summary>
    public void ReiniciarJuego()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor para que no se vea al reiniciar el juego
        Cursor.visible = false; // Hace invisible el cursor para que no se vea al reiniciar el juego
        SceneManager.LoadScene(0); // La escena0 es la escena "de juego" que es la que se reinicia al morir
        GameManager.instance.ResetMuertos(); // Reinicia el contador de enemigos muertos a 0 al reiniciar el juego
    }

    /// <summary>
    /// Función para salir del juego. Se llama al hacer clic en el botón de salir en el panel de muerte.
    /// </summary>
    public void SalirJuego()
    {
        Application.Quit(); // Sale del juego
    }
}
