using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<TriggerVolumeInteractor>())
        {
            Debug.Log(message:"Player Enter Trigger Volume.");
        }
        
    }
}
