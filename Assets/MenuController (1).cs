using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla los botones del menú principal.
/// Asigna cada método público al evento OnClick() del botón correspondiente.
/// </summary>
public class MenuController : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject panelOpciones;   // Sub-panel de opciones (empieza oculto)
    [SerializeField] private GameObject panelCarga;      // Panel de carga falsa (opcional)

    [Header("Configuración")]
    [SerializeField] private string nombreEscenaJuego = "GameScene";

    private void Start()
    {
        // Aseguramos que los paneles secundarios arranquen ocultos
        if (panelOpciones != null) panelOpciones.SetActive(false);
        if (panelCarga != null)    panelCarga.SetActive(false);
    }

    // ---------- BOTÓN JUGAR ----------
    public void Jugar()
    {
        Debug.Log("Botón JUGAR presionado");

        if (panelCarga != null && panelCarga.GetComponent<LoadingScreen>() != null)
        {
            panelCarga.SetActive(true);
            panelCarga.transform.SetAsLastSibling();   // Lo pone al frente
            panelCarga.GetComponent<LoadingScreen>().CargarEscena(nombreEscenaJuego);
        }
        else
        {
            SceneManager.LoadScene(nombreEscenaJuego);
        }
    }

    // ---------- BOTÓN OPCIONES ----------
    // Muestra u oculta el sub-panel de opciones cada vez que se presiona.
    public void ToggleOpciones()
    {
        if (panelOpciones == null)
        {
            Debug.LogWarning("PanelOpciones NO está asignado en el Inspector.");
            return;
        }

        bool nuevoEstado = !panelOpciones.activeSelf;
        panelOpciones.SetActive(nuevoEstado);

        // Si lo estamos mostrando, lo traemos al frente para que no quede tapado
        if (nuevoEstado)
            panelOpciones.transform.SetAsLastSibling();

        Debug.Log("Botón OPCIONES presionado. Panel visible: " + nuevoEstado);
    }

    // ---------- BOTÓN SALIR ----------
    public void Salir()
    {
        Debug.Log("Botón SALIR presionado. Saliendo del juego...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Para probarlo desde el Editor
#endif
    }
}
