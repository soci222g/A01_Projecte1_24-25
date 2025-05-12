using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogos_chuck : MonoBehaviour
{
    [SerializeField] private List<string> BloqueTexto;
    [SerializeField] private int CurrentTextCount;
    private TextMeshPro _textMeshPro;

    [SerializeField] private bool ActivateTexT;
    [SerializeField] private bool nextText = true;
    private float CurrentTimeText;
    private float NextTextTime = 5f;

    [SerializeField] private GameObject square;
    [SerializeField] private camerabehavior cameraBehavior;
    [SerializeField] private int roomNum;
    private AudioSource yap;
    private Controles controles;

    [SerializeField] private GameObject uiTeclado;
    [SerializeField] private GameObject uiMando;

    private void Awake()
    {
        controles = new Controles();
        ActivateTexT = false;
        _textMeshPro = GetComponent<TextMeshPro>();
        CurrentTimeText = 0;
        CurrentTextCount = 0;
        _textMeshPro.SetText(BloqueTexto[CurrentTextCount]);
        yap = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        controles.Base.Enable();
    }

    private void OnDisable()
    {
        controles.Base.Disable();
    }

    private void Update()
    {
        if (cameraBehavior.getCurrentRoom() != roomNum) return;

        if (ActivateTexT)
        {
            if (Input.GetMouseButtonUp(1) || controles.Base.Text.WasReleasedThisFrame())
                nextText = true;

            if ((Input.GetMouseButtonDown(1) || controles.Base.Text.WasPressedThisFrame()) && nextText)
            {
                nextText = false;

                if (CurrentTextCount < BloqueTexto.Count - 1)
                {
                    yap.Play();
                    CurrentTextCount++;
                    _textMeshPro.SetText(BloqueTexto[CurrentTextCount]);
                }
                else
                {
                    ActivateTexT = false;
                    square.SetActive(false);
                }
            }
        }
    }

    public void ActivateText()
    {
        ActivateTexT = true;

        if (DispositivoInputDetector.Detectado)
        {
            if (DispositivoInputDetector.DispositivoUsado == "mando")
            {
                uiMando.SetActive(true);
                uiTeclado.SetActive(false);
            }
            else if (DispositivoInputDetector.DispositivoUsado == "teclado")
            {
                uiMando.SetActive(false);
                uiTeclado.SetActive(true);
            }
        }
    }
}
