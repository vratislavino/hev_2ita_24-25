using System;
using UnityEngine;

public class FoolCatcher : MonoBehaviour
{
    Camera cam;

    internal void Remove(Fool fool)
    {

    }

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 30f))
            {
                var fool = hit.collider.GetComponent<Fool>();
                if(fool != null)
                {
                    fool.Hit();
                }
            }
        }
    }
}
