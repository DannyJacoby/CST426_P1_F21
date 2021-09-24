using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    List<string> fishList;

    int target;

    List<string> lastCaught = new List<string>();

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
                string materia = hit.transform.GetComponent<Renderer>().material.name.ToString();
                string[] color = materia.Split();
                Destroy(hit.transform.gameObject);
                if (color[0].CompareTo(fishList[target]) == 0)
                {
                    print("MATCH!");
                    AdjustCaught(color[0]);
                    target++;
   
                    if (target == fishList.Count)
                    {
                        print("Load Next Level");
                        won.Invoke();
                    }
                }
                else
                {
                    print("WrongFish");
                    lost.Invoke();
                }

            }
        }

    }
    void AdjustCaught(string color)
    {
        lastCaught.Add(color);
        if(lastCaught.Count == 5)
        {
            lastCaught.RemoveAt(0);
        }
    }
    public List<string> getLastFour()
    {
        return lastCaught;
    }
}
