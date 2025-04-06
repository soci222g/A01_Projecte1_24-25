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
            Debug.LogWarning("Fleep o imageUI no est�n asignados en el Inspector.");
            return;
        }

        // Si el timer est� activo (es decir, la habilidad est� en cooldown)
        if (detector.GetGroundDetect() == false)
        {
            imageUI.sprite = spriteVacio;  // Muestra el sprite vac�o
        }
        else
        {
            imageUI.sprite = spriteLleno;  // Muestra el sprite lleno cuando el cooldown termina
        }
    }
}
