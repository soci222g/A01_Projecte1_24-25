using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSaveScean : MonoBehaviour
{
     public void ResetScean()
    {
        PlayerPrefs.DeleteKey("Secan");
    }
}
