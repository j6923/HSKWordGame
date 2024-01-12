using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        
    }
}
