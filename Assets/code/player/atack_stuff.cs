using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class atack_stuff : MonoBehaviour
{

    atack atk;

    void Start()
    {
        atk = GetComponentInChildren<atack>();
    }

    void lat_hitbox_deactivate()
    {
        atk.lat_hitbox_deactivate();
    }

    void down_hitbox_deactivate()
    {
        atk.down_hitbox_deactivate();
    }

    void cooldown_off()
    {
        atk.cooldown_off();
    }

    void atk_anim()
    {
        atk.atk_anim();
    }

    void air_atk_anim()
    {
        atk.air_atk_anim();
    }
}
