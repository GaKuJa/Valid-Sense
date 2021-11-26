using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIcon : MonoBehaviour
{
    RectTransform rectTransform;
    public bool shouldRotate;
    [SerializeField] float rotationSpeed;
    Vector3 rotationVec;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!shouldRotate) return;
        Rotate();
    }

    void Rotate()
    {
        rotationVec += Vector3.forward * Time.deltaTime * -rotationSpeed;
        rectTransform.localRotation = Quaternion.Euler(rotationVec);
    }
}
