using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Vector3 target;
    LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }
    }

    void Shoot()
    {
        Plane plane = new Plane(Vector3.back, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            target = ray.GetPoint(distance);
      
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target);
            line.enabled = true;
        }
        if(Physics.Raycast(ray, out RaycastHit hit)){
            if (hit.transform.CompareTag("Fish"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

}
