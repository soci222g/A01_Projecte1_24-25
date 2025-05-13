using System.Collections;
using UnityEngine;

public class Fleep : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    [SerializeField]
    private bool fleep;

    private bool fleepControler = true;

    [SerializeField]
    private bool flying;

    [SerializeField]
    private float curentfleepTime;

    [SerializeField] private ParticleSystem jumpPart;
    [SerializeField] private ParticleSystem jumpPartF;
    [SerializeField] private AudioSource Audio;

    private Controles controles;

    void Awake()
    {
        controles = new Controles();
        controles.Base.Flip.performed += ctx => OnFlipPressed();
    }

    void OnEnable()
    {
        controles.Base.Enable();
    }

    void OnDisable()
    {
        controles.Base.Disable();
    }

    void Start()
    {
        flying = false;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GetComponent<GroundDetector>().GetGroundDetect())
            fleep = false; // Resetea el fleep si estás en el suelo
    }

    private void OnFlipPressed()
    {
        if (GetComponent<GroundDetector>().GetGroundDetect())
        {
            createJumpPart();
            fleep = true;
            fleepControler = !fleepControler;

            if (GetComponentsInParent<movPlat_movment>() != null)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Debug.Log("onMovePLatform");
            }

            rb.gravityScale *= -1;
            sr.flipY = !sr.flipY;
        }
    }

    void createJumpPart()
    {
        if (fleepControler)
            jumpPart.Play();
        else
            jumpPartF.Play();
    }

    public bool GetFleepControler()
    {
        return fleepControler;
    }

    public float GetTimer()
    {
        return curentfleepTime;
    }

    public bool GetFlying()
    {
        return flying;
    }

    public void SetFleep()
    {
        fleep = true;
        fleepControler = !fleepControler;
        rb.gravityScale *= -1;
        sr.flipY = !sr.flipY;
        float newVerticalVelocity = rb.velocity.y * 0.1f;
        Debug.Log(newVerticalVelocity);
        rb.velocity = new Vector2(rb.velocity.x, newVerticalVelocity);
    }
}
