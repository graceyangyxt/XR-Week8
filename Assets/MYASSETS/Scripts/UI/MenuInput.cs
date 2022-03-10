using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManager;
    public InputActionReference menuButton;
    
    // Start is called before the first frame update
    private void Start()
    {
        menuButton.action.started += MenuButtonPressed;
    }

    private void MenuButtonPressed(InputAction.CallbackContext obj)
    {
        if (_menuManager.gameObject.activeSelf)
        {
            _menuManager.CloseMenu();
            
        }
        else
        {
            _menuManager.gameObject.SetActive(true);
           
        }
    }
   
}
