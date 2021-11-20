using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public string sceneName;    
    // Start is called before the first frame update
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("awe");
        SceneManager.LoadScene(sceneName);
    }

}
 