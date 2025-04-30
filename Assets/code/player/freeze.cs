using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    private bool Frezze = false;

    private float currentDuration;
    private float Duration;



    // Update is called once per frame
    void Update()
    {
        if(currentDuration > 0 && !Frezze)
        {
            StartCoroutine(DoFrezze());
        }
    }

    public void setDurationFreeze(float duration)
    {
        Duration = duration;
        currentDuration = duration;
    }
    IEnumerator DoFrezze()
    {
        Frezze = true;
        float SafeTimeScale = Time.timeScale;
        Time.timeScale = 0;

        yield return new WaitForSeconds(Duration);

        Time.timeScale = SafeTimeScale;
        currentDuration = 0;
        Frezze = false;

    }
}
