using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hands
{
    public class XRTeleportManager : MonoBehaviour
    {
        [SerializeField] private XRBaseInteractor _teleportController;
        [SerializeField] private XRBaseInteractor _mainController;
        [SerializeField] private Animator _handAnimator;
        [SerializeField] private GameObject _pointer;

        private void Start()
        {
            _teleportController.selectEntered.AddListener(MoveSelectionToMainController);
        }

        private void MoveSelectionToMainController(SelectEnterEventArgs arg0)
        {
            if(arg0.interactable is BaseTeleportationInteractable) return;
            
            if (arg0.interactable) _teleportController.interactionManager.ForceSelect(_mainController,arg0.interactable);
        }

        // Update is called once per frame
        private void Update()
        {
            _pointer.SetActive(_handAnimator.GetCurrentAnimatorStateInfo(layerIndex:0).IsName("Point")&& _handAnimator.gameObject.activeSelf);
        }
    }
}

