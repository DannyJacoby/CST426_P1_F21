using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneMngt : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.CompareTag("UI"))
                {
                    LoadScene(hit.collider.gameObject.name);
                }
            }
        }
    }
    
    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading new scene called " + sceneName);

        if (string.Equals(sceneName, "Quit"))
        {
            Debug.Log("Quitting Now");
            Application.Quit();
            return;
        }
        SceneManager.LoadScene(sceneName);
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
}
