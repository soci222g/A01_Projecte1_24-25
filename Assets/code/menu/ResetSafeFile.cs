using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSafeFile : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    

    
    public void ResetSafe()
    {
        PlayerPrefs.DeleteKey("X");
        PlayerPrefs.DeleteKey("Y");
        PlayerPrefs.DeleteKey("Z");
        PlayerPrefs.DeleteKey("CameraPosition");
        PlayerPrefs.DeleteKey("Key");
        PlayerPrefs.DeleteKey("Secan");
    }
}
