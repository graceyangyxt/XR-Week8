using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    public enum PatrolType
    {
        Loop =0,
        PingPong = 1
    }

    [SerializeField] private Color _patrolRouteColor = Color.green;
    public PatrolType patrolType;
    public List<Transform> route;
    
    // Start is called before the first frame update
   

    [Button(name:"Add Patrol Point")]
    private void AddPatrolPoint()
    {
        Debug.Log("Button Pressed");
        GameObject thisPoint = new GameObject();
        thisPoint.transform.position = transform.position;
        thisPoint.transform.parent = transform;
        thisPoint.name = "Point" + (route.Count + 1);
        route.Add(thisPoint.transform);
    }

    [Button("Reverse Patrol Route")]
    private void ReversePatrolRoute()
    {
        route.Reverse();
    }

    private void OnDrawGizmos()
    {
       //#if UNITY_EDITOR
       //   Handles.Label(transform.position, gameObject.name);
      // #endif
      Gizmos.color = _patrolRouteColor;

      for (int i = 0; i < route.Count-1; i++)
      {
          //Debug.Log(i);
          Gizmos.DrawLine(route[i].position, route[i+1].position);
      }

      if (patrolType == PatrolType.Loop)
      {
          Debug.Log("Patrol type is LOOP");
          Gizmos.DrawLine(route[route.Count - 1].position, route[0].position);
      }
    }
   
}
