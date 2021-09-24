using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    Vector3 spawn;

    public UnityEvent atCenter;

    string[] colors =
    {
        "red",
        "blue",
        "yellow",
        "black"
    };

     List<string> list;

    

    void reSizeParent(int cap, float displacement)
    {
        //scale gameObject to fit all fish
        transform.localScale = new Vector3(cap * displacement, 1, 1);

        //adjust world location
        float zeta = cap;
        transform.position = new Vector3(12 + (displacement * cap), 0, zeta);

        //set spawn locatiom
        spawn = new Vector3(transform.position.x + transform.localScale.x / -2, transform.position.y, transform.position.z);
        spawn.x += displacement / 2;

        instatiatList(displacement);

    }
    //For user to use
    public void generateNewList(int cap,float displacement)
    {
        list = new List<string>();
        for (int i = 0; i < cap; i++)
        {
            list.Add(colors[Random.Range(0, colors.Length)]);
        }
        reSizeParent(list.Capacity,displacement);
    }
    //for user to use 
    public void addToList(List<string> otherList,int count,float displacemet)
    {
        list = otherList;
        for(int i = 0; i < count; i++)
        {
            list.Add(colors[Random.Range(0, colors.Length)]);
        }
        reSizeParent(list.Capacity, displacemet);
    }

    void instatiatList(float displacement)
    {
        for (int i = 0; i < list.Capacity; i++)
        {
            var temp = Instantiate(prefab, spawn, Quaternion.identity);
            Destroy(temp.GetComponent<Move>()); //take away move behaviour

            //render its color
            Renderer rend = temp.transform.GetChild(0).transform.GetComponent<Renderer>();
            rend.material = Resources.Load<Material>(list[i]);

            temp.transform.parent = gameObject.transform;
            spawn.x += displacement;
        }
    }
    public void moveAccross()
    {
        float speed = 5;
        //move level generator game object until centered on scene 
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), step);
    }

    public List<string> getList() { return list; }

    private void FixedUpdate()
    {
        if(transform.position.x == 0)
        {
            atCenter.Invoke();
        }
    }

}

/* Instatiate and child prefabs 
 * Move accross screen 
 * 
 * class Prefab{
 *  
 *  Data:
 *  
 *  GameObject prefab;
 *  string[] colors; 
 *  static public List<string>;
 *  Vector3 spawn;
 *  
 *  
 *  Functions:
 *  
 *  
 *  reSizeParent(int cap,float displacement);//reSize parent obj to fit all children
 *  
 *  public generateNewList(int cap);//create brand new list of colors
 *  public addToList(List<string> );//Add to existing list
 *  
 *  instatiatList()//instatiate prefabs into parent object
 *  
 *  public moveAccross();//move parent object accross screen
 *  
 *  getList()//return list 
 *  
 *  
 * 
 * 
 * 
 * 
 * 
 * 
 */