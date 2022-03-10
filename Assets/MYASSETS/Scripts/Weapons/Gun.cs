using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.PhysicsModule;

namespace Weapons
{
   
    
    public class Gun : MonoBehaviour
    {
        [SerializeField] private XRGrabInteractable _grabInteractable;
        [SerializeField] protected Transform _gunBarrel;
        [SerializeField] protected XRSocketInteractor _ammoSocket;
        // Start is called before the first frame update

        protected AmmoClip _ammoClip;
        protected virtual void Start()
        {
            Assert.IsNotNull(_grabInteractable,message:"You have not assigned a grab interactable to gun"+ name);
            Assert.IsNotNull(_gunBarrel,message:"You have not assigned a grab interactable to gun"+ name);
            Assert.IsNotNull(_ammoSocket,message:"You have not assigned a grab interactable to gun"+ name);

            _ammoSocket.selectEntered.AddListener(AmmoAttached);
            _ammoSocket.selectExited.AddListener(AmmoDetached);

            _grabInteractable.activated.AddListener(Fire);
        }

        protected virtual void AmmoAttached(SelectEnterEventArgs arg0)
        {
            IgnoreCollision(arg0.interactable, true);
            _ammoClip = arg0.interactable.GetComponent<AmmoClip>();

        }
        protected virtual void AmmoDetached(SelectExitEventArgs arg0)
        {
            IgnoreCollision(arg0.interactable, false);
            _ammoClip = null;
        }
        protected virtual void Fire(ActivateEventArgs arg0)
        {
            if(!CanFire()) return;

            _ammoClip.amount -= 1;
        }

        protected virtual bool CanFire()
        {
            if (!_ammoClip)
            {
                Debug.Log("No Ammo Inserted");
                return false;
            }
            
            if (_ammoClip.amount <= 0)
            {
                _ammoClip.amount = 0;
                Debug.Log("No Ammo Left");
                return false;
            }

            return true;
        }

        private void IgnoreCollision(XRBaseInteractable interactable, bool ignore)
        {
            var myColliders = GetComponentsInChildren<Collider>();
            foreach (var myCollider in myColliders)
            {
                foreach (var interactableCollider in interactable.colliders)
                {
                    Physics.IgnoreCollision(myCollider, interactableCollider, ignore);
                }
            }
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
    }    
}

