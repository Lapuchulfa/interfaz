using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Si usas TextMeshPro para el porcentaje, descomenta la línea de abajo
// using TMPro;

/// <summary>
/// Barra de carga falsa + carga real de la escena en segundo plano.
/// Coloca este script en el "PanelCarga" y arrástralo al campo panelCarga del MenuController.
/// </summary>
public class LoadingScreen : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private Slider barraProgreso;      // Un Slider actúa como barra de progreso
    [SerializeField] private Text  textoPorcentaje;     // Opcional (usa TMP_Text si tienes TextMeshPro)

    [Header("Configuración")]
    [SerializeField] private float duracionFalsa = 2f;  // Segundos de "carga" simulada

    public void CargarEscena(string nombreEscena)
    {
        StartCoroutine(RutinaDeCarga(nombreEscena));
    }

    private IEnumerator RutinaDeCarga(string nombreEscena)
    {
        // 1) Carga FALSA animada (para el efecto de juiciness)
        float tiempo = 0f;
        while (tiempo < duracionFalsa)
        {
            tiempo += Time.deltaTime;
            float progreso = Mathf.Clamp01(tiempo / duracionFalsa);

            if (barraProgreso != null)  barraProgreso.value = progreso;
            if (textoPorcentaje != null) textoPorcentaje.text = Mathf.RoundToInt(progreso * 100f) + "%";

            yield return null;
        }

        // 2) Carga REAL de la escena (en segundo plano)
        AsyncOperation op = SceneManager.LoadSceneAsync(nombreEscena);
        while (!op.isDone)
            yield return null;
    }
}
