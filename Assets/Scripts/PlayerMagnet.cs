using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    [SerializeField]float magneticForce = default;   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * magneticForce);
        }
    }
}
