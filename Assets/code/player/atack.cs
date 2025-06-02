using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class atack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D latHitbox;
    [SerializeField] private BoxCollider2D downHitbox;
    [SerializeField] private int atackCooldown;
    [SerializeField] private int atackDuration;
    [SerializeField] private bool onCooldown;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSR;
    [SerializeField] private float bounce;
    [SerializeField] private Transform playerTR;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float offset;
    [SerializeField] private float camShakeForce;
    [SerializeField] private float camShakeTimer;
    [SerializeField] private AudioSource swingAudio;
    [SerializeField] private AudioSource HitAudio;

    private int countCooldown;
    private int atackDurationCounter;

    private actionState state;
    private GroundDetector gD;
    private movement movement;
    private freeze frez;
    private Controles controles;

    void Awake()
    {
        controles = new Controles();
        controles.Base.Attack.performed += ctx => OnAttackPressed();
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
        state = GetComponentInParent<actionState>();
        gD = GetComponentInParent<GroundDetector>();
        downHitbox.enabled = false;
        latHitbox.enabled = false;
        onCooldown = false;
        frez = GetComponentInParent<freeze>();
        movement = GetComponentInParent<movement>();
    }

    void FixedUpdate()
    {
        latHitbox.offset = new Vector2(playerSR.flipX ? -1.3f : 1.3f, 0);
        downHitbox.offset = new Vector2(0, playerSR.flipY ? offset : -offset);
    }

    private void OnAttackPressed()
    {
        if (onCooldown || !state.getActionState()) return;

        swingAudio.Play();
        state.startAction();

        if (gD.GetGroundDetect())
        {
            latHitbox.enabled = true;
            animator.SetBool("IsAtack", true);
            playerRB.velocity = Vector3.zero;
            movement.setSpeed(1f);
        }
        else
        {
            animator.SetBool("IsAirAtack", true);
        }

        onCooldown = true;
        atackDurationCounter = 0;
        Debug.Log("Attack triggered");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && collision.TryGetComponent(out EnemyHP enemyHp))
        {
            HitAudio.Play();
            enemyHp.setHP(1);
            Animator enemyAnim = collision.GetComponent<Animator>();
            enemyAnim.SetBool("damage", true);

            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            GetComponentInParent<CameraShake>().ShakeCamera(camShakeForce, camShakeTimer);

            if (enemyHp.getHP() <= 0)
            {
                frez.setDurationFreeze(0.15f);
            }

            if (!gD.GetGroundDetect())
            {
                downHitbox.enabled = false;
                if (!playerSR.flipY)
                    playerRB.AddForce(transform.up * bounce);
                else
                    playerRB.AddForce(transform.up * -bounce);
            }

            if (collision.GetComponent<DesactivarColliderTimer>() != null)
            {
                collision.GetComponent<DesactivarColliderTimer>().StartDeactivateCollider();
            }
        }
        else if (collision.CompareTag("bounce"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);

            if (!playerSR.flipY)
                playerRB.AddForce(transform.up * bounce);
            else
                playerRB.AddForce(transform.up * -bounce);
        }
    }

    public void lat_hitbox_deactivate()
    {
        latHitbox.enabled = false;
        movement.setSpeed(8f);
    }

    public void down_hitbox_activate()
    {
        downHitbox.enabled = true;
    }

    public void down_hitbox_deactivate()
    {
        downHitbox.enabled = false;
    }

    public void cooldown_off()
    {
        onCooldown = false;

        state.endAction();
    }

    public void atk_anim()
    {
        animator.SetBool("IsAtack", false);
    }

    public void air_atk_anim()
    {
        animator.SetBool("IsAirAtack", false);
    }
}
