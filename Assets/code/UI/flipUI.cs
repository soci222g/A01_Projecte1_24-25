using UnityEngine;
using UnityEngine.UI;

public class flipUI : MonoBehaviour
{
    [SerializeField] private Fleep fleep;
    [SerializeField] private GroundDetector detector;
    [SerializeField] private Image imageUI;
    [SerializeField] private Sprite spriteVacio;
    [SerializeField] private Sprite spriteLleno;

    void Update()
    {
        if (fleep == null || imageUI == null)
        {
            Debug.LogWarning("Fleep o imageUI no están asignados en el Inspector.");
            return;
        }

        // Si el timer está activo (es decir, la habilidad está en cooldown)
        if (detector.GetGroundDetect() == false)
        {
            imageUI.sprite = spriteVacio;  // Muestra el sprite vacío
        }
        else
        {
            imageUI.sprite = spriteLleno;  // Muestra el sprite lleno cuando el cooldown termina
        }
    }
}
