using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public static UnityEvent FinishEvent = new UnityEvent();

    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponentInParent<SnakeManager>()._bodySnake[0])
        {
            FinishEvent?.Invoke();      
        }
    }
}
