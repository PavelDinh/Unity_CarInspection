using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;

    void Start()
    {
        var Objects = GameObject.FindGameObjectsWithTag("Camera");
        for (int i = 0; i < Objects.Length; i++)
        {
            cameras.Add(Objects[i].GetComponent<Camera>());
            cameras[i].gameObject.SetActive(false);
        }
        cameras[1].gameObject.SetActive(true);
    }

    public void SwitchCamera(int index)
    {
        if(index == 1)
        {
            cameras[index].gameObject.SetActive(false);
            index = 0;
            cameras[index].gameObject.SetActive(true);
        }
        else
        {
            cameras[index].gameObject.SetActive(false);
            cameras[index+1].gameObject.SetActive(true);
        }
    }
}
