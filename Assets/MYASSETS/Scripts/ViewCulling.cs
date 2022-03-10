using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(FieldOfView))]
public class ViewCulling : MonoBehaviour
{
    private FieldOfView _fov;

    private List<Transform> _enemiesInViewLastFrame;
    // Start is called before the first frame update
    void Start()
    {
        _fov = GetComponent<FieldOfView>();
        _enemiesInViewLastFrame = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var enemiesOutOfView = _enemiesInViewLastFrame.Except(_fov.visibleObjects).ToList();
        foreach (var enemy in enemiesOutOfView)
        {
            Debug.Log(enemy.name + "is out of view");
            var rend = enemy.GetComponentInChildren<SkinnedMeshRenderer>();
            if (rend)
            {
                rend.enabled = false;
            }
        }
        
        var enemiesInViewNow = _fov.visibleObjects.Except(_enemiesInViewLastFrame).ToList();
        foreach (var enemy in enemiesInViewNow)
        {
            Debug.Log(enemy.name + "is in view");
            var rend = enemy.GetComponentInChildren<SkinnedMeshRenderer>();
            if (rend)
            {
                rend.enabled = true;
            }
        }
        _enemiesInViewLastFrame = new List<Transform>(_fov.visibleObjects);
    }
}
