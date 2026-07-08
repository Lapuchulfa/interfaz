using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controla la música de fondo y el botón de silenciar/activar sonido.
/// Colócalo en el mismo objeto que tiene el AudioSource de la música
/// (o arrastra el AudioSource desde otro objeto en el campo correspondiente).
/// </summary>
public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource musicaFondo;

    [Header("Botón Mute - Imagen (recomendado)")]
    [SerializeField] private Image imagenBotonMute;       // El componente Image del botón (o un hijo "Icon")
    [SerializeField] private Sprite spriteSonidoActivo;    // Ícono de bocina encendida
    [SerializeField] private Sprite spriteSonidoMuteado;   // Ícono de bocina silenciada

    [Header("Botón Mute - Texto (opcional, déjalo vacío si no lo usas)")]
    [SerializeField] private TMP_Text textoBotonMute;
    [SerializeField] private string textoSonidoActivo = "ON";
    [SerializeField] private string textoSonidoMuteado = "OFF";

    private bool muteado = false;

    private void Start()
    {
        ActualizarBoton();
    }

    // ---------- BOTÓN MUTE / UNMUTE ----------
    public void ToggleMute()
    {
        if (musicaFondo == null)
        {
            Debug.LogWarning("AudioManager: no hay AudioSource asignado.");
            return;
        }

        muteado = !muteado;
        musicaFondo.mute = muteado;

        ActualizarBoton();

        Debug.Log("Música " + (muteado ? "silenciada" : "activada"));
    }

    private void ActualizarBoton()
    {
        // Cambia el ícono (si está asignado)
        if (imagenBotonMute != null)
        {
            Sprite spriteNuevo = muteado ? spriteSonidoMuteado : spriteSonidoActivo;
            if (spriteNuevo != null)
                imagenBotonMute.sprite = spriteNuevo;
        }

        // Cambia el texto (si está asignado, opcional)
        if (textoBotonMute != null)
            textoBotonMute.text = muteado ? textoSonidoMuteado : textoSonidoActivo;
    }
}
