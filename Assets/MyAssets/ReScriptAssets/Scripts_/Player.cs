using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    List<string> fishList;

    int target;

    public UnityEvent won;
    public UnityEvent lost;

    public void setfishList(List<string> list)
    {
        fishList = list;
        target = 0;
    }

    public void fish()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Fish"))
            {
                print("won");
                won.Invoke();
                string caught = hit.transform.GetComponent<Renderer>().material.name.ToString();
                string[] color = caught.Split();
                Destroy(hit.transform.gameObject);
                //if (color[0].CompareTo(fishList[target]) == 0)
                //{
                  //  print("MATCH!");
                  //  target++;
                   // if (target == fishList.Capacity)
                    //    won.Invoke();
               // }
            }
        }

    }
}
