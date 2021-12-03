using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform cameraTransfrom;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cameraTransfrom.forward);
    }
}
