using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [Tooltip("Seconds until this object is destroyed.")]
    [SerializeField] float _duration = 1f;
    
    void Start()
    {
        Destroy(gameObject, _duration);
    }

    
}
