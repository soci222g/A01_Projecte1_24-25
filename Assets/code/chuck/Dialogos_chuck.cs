using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogos_chuck : MonoBehaviour
{
    [SerializeField]
    List<string> BloqueTexto;
    [SerializeField]
    private int CurrentTextCount;

    private TextMeshPro _textMeshPro;
    [SerializeField]
    private float CurrentTimeText;
    private float NextTextTime;

    [SerializeField]
    private bool ActivateTexT;

    [SerializeField] private GameObject square;

    [SerializeField]bool nextText = true;


    private void Awake()
    {
        ActivateTexT = false;
        _textMeshPro = GetComponent<TextMeshPro>();
        CurrentTimeText = 0;
        NextTextTime = 5;
        CurrentTextCount = 0;
        _textMeshPro.SetText(BloqueTexto[CurrentTextCount]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            nextText = true;
        }

        if (ActivateTexT)
        {
            if (Input.GetMouseButtonDown(1) && nextText)
            {
                nextText = false;
                Debug.Log("yapyapyap");

                if (CurrentTextCount <= BloqueTexto.Count)
                {
                    CurrentTextCount++;
                    for (int i = 0; i < BloqueTexto.Count; i++)
                    {
                        if (i == CurrentTextCount)
                        {
                            _textMeshPro.SetText(BloqueTexto[i]);
                        }

                    }
                }
                if (CurrentTextCount >= BloqueTexto.Count)
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
    }


}
