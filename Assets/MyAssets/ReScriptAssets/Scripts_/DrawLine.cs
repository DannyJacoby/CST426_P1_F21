using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Vector3 target;//fishing line target
    LineRenderer line;

    public void Draw()
    {
        Plane plane = new Plane(Vector3.back, 0);//used to calcualte world space coordinates

        float distance;
        //calculate our target end drawing vertex
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            target = ray.GetPoint(distance);

            line.SetPosition(0, transform.position);
            line.SetPosition(1, target);
            line.enabled = true;
        }
    }
}
