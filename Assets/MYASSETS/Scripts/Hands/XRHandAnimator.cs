using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hands
{
 
    public class XRHandAnimator : MonoBehaviour
    {
        [SerializeField] private ActionBasedController _controller;
        [SerializeField] private Animator _animator;

        [SerializeField] private MenuManager _menuManager;
        // Start is called before the first frame update
        void Start()
        {
            _controller.selectAction.action.started += Point;
            _controller.selectAction.action.canceled += PointReleased;

            _controller.activateAction.action.started += Fist;
            _controller.selectAction.action.canceled += FistReleased;
        }

        private void OnDestroy()
        {
            _controller.selectAction.action.started -= Point;
            _controller.selectAction.action.canceled -= PointReleased;

            _controller.activateAction.action.started -= Fist;
            _controller.selectAction.action.canceled -= FistReleased;
        }
        
        private void Fist(InputAction.CallbackContext obj)
        {
            if(_menuManager.gameObject.activeSelf) _animator.SetBool("Fist", true);
        }
        private void FistReleased(InputAction.CallbackContext obj)
        {
            _animator.SetBool("Fist", false);
        }

        private void Point(InputAction.CallbackContext ctx)
        {
            _animator.SetBool("Point", true);
        }
        private void PointReleased(InputAction.CallbackContext obj)
        {
            _animator.SetBool("Point", false);
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}