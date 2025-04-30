using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChuckDialogs : MonoBehaviour
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
    [SerializeField] private GameObject chuck;


    private void Awake()
    {
        ActivateTexT = false;
        _textMeshPro = GetComponent<TextMeshPro>();
        CurrentTimeText = 0;
        NextTextTime = 7f;
        CurrentTextCount = 0;
        _textMeshPro.SetText(BloqueTexto[CurrentTextCount]);
    }

    private void FixedUpdate()
    {

        if (ActivateTexT)
        {
            if (CurrentTimeText >= NextTextTime && CurrentTextCount <= BloqueTexto.Count)
            {
                CurrentTextCount++;
                for (int i = 0; i < BloqueTexto.Count; i++)
                {
                    if (i == CurrentTextCount)
                    {
                        _textMeshPro.SetText(BloqueTexto[i]);
                        CurrentTimeText = 0;
                    }

                }
            }
            else if (CurrentTextCount > BloqueTexto.Count)
            {
                ActivateTexT = false;
                CurrentTimeText += Time.deltaTime;
                square.SetActive(false);
                chuck.GetComponent<chuckSpawnTimer>().GetSr().enabled = false;
                
            }
            else
            {
                CurrentTimeText += Time.deltaTime;

            }
        }


    }

    public void ActivateText()
    {
        ActivateTexT = true;
    }


}
