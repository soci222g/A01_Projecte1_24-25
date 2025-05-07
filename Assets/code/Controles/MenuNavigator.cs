using UnityEngine;
using UnityEngine.EventSystems;

public class SelectFirstButton : MonoBehaviour
{
    [SerializeField] private GameObject firstButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
