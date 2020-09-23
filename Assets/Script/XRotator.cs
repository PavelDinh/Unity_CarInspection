using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XRotator : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 20f;

    void Update()
    {
        if(Input.GetMouseButton(0) && UIBlocker.BlockedByUI == false)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotX);
        }
    }
}
