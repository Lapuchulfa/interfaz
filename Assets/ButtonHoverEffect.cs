using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Efecto de crecer al pasar el cursor y encoger al hacer clic.
/// Coloca este script en CADA botón (Play, Options, Quit).
/// No requiere configurar nada en el Inspector: funciona solo.
/// </summary>
public class ButtonHoverEffect : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float escalaHover = 1.10f;   // Tamaño al pasar el cursor
    [SerializeField] private float escalaClick = 0.95f;   // Tamaño al presionar
    [SerializeField] private float velocidad   = 10f;     // Suavidad de la transición

    private Vector3 escalaOriginal;
    private Vector3 escalaObjetivo;

    private void Start()
    {
        escalaOriginal = transform.localScale;
        escalaObjetivo = escalaOriginal;
    }

    private void Update()
    {
        // Interpolación suave hacia la escala objetivo
        transform.localScale = Vector3.Lerp(
            transform.localScale, escalaObjetivo, Time.unscaledDeltaTime * velocidad);
    }

    public void OnPointerEnter(PointerEventData e) => escalaObjetivo = escalaOriginal * escalaHover;
    public void OnPointerExit(PointerEventData e)  => escalaObjetivo = escalaOriginal;
    public void OnPointerDown(PointerEventData e)  => escalaObjetivo = escalaOriginal * escalaClick;
    public void OnPointerUp(PointerEventData e)    => escalaObjetivo = escalaOriginal * escalaHover;
}
