using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla las opciones reales del menú: volumen de música y pantalla completa.
/// Colócalo en el PanelOpciones (o en el MenuManager, como prefieras).
/// </summary>
public class OpcionesController : MonoBehaviour
{
    [Header("Volumen")]
    [SerializeField] private AudioSource musicaFondo;   // Arrastra el mismo AudioSource de tu música
    [SerializeField] private Slider sliderVolumen;       // El Slider dentro de PanelOpciones

    [Header("Pantalla Completa")]
    [SerializeField] private Toggle togglePantallaCompleta;  // El Toggle dentro de PanelOpciones

    private void Start()
    {
        // --- Inicializar el slider con el volumen actual ---
        if (sliderVolumen != null && musicaFondo != null)
        {
            sliderVolumen.minValue = 0f;
            sliderVolumen.maxValue = 1f;
            sliderVolumen.value = musicaFondo.volume;

            // Cada vez que se mueva el slider, llama a CambiarVolumen
            sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        }

        // --- Inicializar el toggle con el estado actual de pantalla completa ---
        if (togglePantallaCompleta != null)
        {
            togglePantallaCompleta.isOn = Screen.fullScreen;

            // Cada vez que se presione el toggle, llama a CambiarPantallaCompleta
            togglePantallaCompleta.onValueChanged.AddListener(CambiarPantallaCompleta);
        }
    }

    // ---------- VOLUMEN ----------
    public void CambiarVolumen(float nuevoValor)
    {
        if (musicaFondo != null)
            musicaFondo.volume = nuevoValor;

        Debug.Log("Volumen ajustado a: " + nuevoValor);
    }

    // ---------- PANTALLA COMPLETA ----------
    public void CambiarPantallaCompleta(bool activo)
    {
        Screen.fullScreen = activo;
        Debug.Log("Pantalla completa: " + activo);
    }
}
