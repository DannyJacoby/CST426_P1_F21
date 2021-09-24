using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    List<string> fishList;

    int target;

    List<string> lastCaught = new List<string>();
    bool canfish = true;

    public UnityEvent won;
    public UnityEvent lost;
    public UnityEvent hitFish;

 

    public void setfishList(List<string> list)
    {
        fishList = list;
        target = 0;

    }

    public void fish()
    {
        if (canfish)
        {
            canfish = false;
            GameObject.Find("GameManager").GetComponent<FXManager>().playSound("cast",0.5f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Fish"))
                {
                    hitFish.Invoke();
                    string materia = hit.transform.GetComponent<Renderer>().material.name.ToString();
                    string[] color = materia.Split();
                    Destroy(hit.transform.gameObject);
                    AdjustCaught(color[0]);
                    if (color[0].CompareTo(fishList[target]) == 0)
                    {
                        print("MATCH!");

                        target++;
                        GameObject.Find("Canvas").GetComponent<HudManager>().upDateText();
                        if (target == fishList.Count)
                        {
                            print("Load Next Level");
                            won.Invoke();
                        }
                    }
                    else
                    {
                        GameObject.Find("GameManager").GetComponent<FXManager>().playSound("wrong",0.5f);
                        print("WrongFish");
                        lost.Invoke();
                    }

                }
            }
            StartCoroutine(enableFishing());
        }

    }
    IEnumerator enableFishing()
    {
        yield return new WaitForSeconds(.5f);
        canfish = true;
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
    public int currentCount()
    {
        return target;
    }
    public int totalNeeded()
    {
        return fishList.Count;
    }
}
