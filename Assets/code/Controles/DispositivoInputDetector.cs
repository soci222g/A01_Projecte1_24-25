using UnityEngine;
using UnityEngine.InputSystem;

public class DispositivoInputDetector : MonoBehaviour
{
    public static string DispositivoUsado = ""; // "teclado" o "mando"
    public static bool Detectado = false;

    [SerializeField] GameObject uiTeclado;
    [SerializeField] GameObject uiMando;

    private void Update()
    {
        if (Detectado) return;

        if (Gamepad.current != null && Gamepad.current.leftStick.ReadValue().magnitude > 0.2f)
        {
            DispositivoUsado = "mando";
            Detectado = true;
            uiMando.SetActive(true);
            uiTeclado.SetActive(false);
            Debug.Log("Dispositivo inicial: MANDO");
        }
        else if (Keyboard.current != null && Keyboard.current.dKey.wasPressedThisFrame)
        {
            DispositivoUsado = "teclado";
            Detectado = true;
            uiMando.SetActive(false);
            uiTeclado.SetActive(true);
            Debug.Log("Dispositivo inicial: TECLADO");
        }
    }
}
