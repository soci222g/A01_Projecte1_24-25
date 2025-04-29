using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuckSpawnTimer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject dialegChuck;
    [SerializeField] private GameObject squareChuck;
    [SerializeField] private float detectionRadiusChuk;
    private SpriteRenderer sr;
    private float timer = 0f;
    [SerializeField] private float timerLength;
    private bool startTextChuck = false;

    // Start is called before the first frame update
    void Start()
    {
        dialegChuck.SetActive(false);
        this.sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer2 = Vector2.Distance(transform.position, player.position);
        //Debug.Log(distanceToPlayer2);
        timer += 0.1f;
        if (distanceToPlayer2 < detectionRadiusChuk && startTextChuck == false && timer >= timerLength)
        {
            startTextChuck = true;
            dialegChuck.SetActive(true);
            squareChuck.SetActive(true);
            this.sr.enabled = true;
        }
        else if (distanceToPlayer2 < detectionRadiusChuk)
        {
            dialegChuck.GetComponent<ChuckDialogs>().ActivateText();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadiusChuk);
    }

    public SpriteRenderer GetSr()
    {
        return sr;
    }
}

