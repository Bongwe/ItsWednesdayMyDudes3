using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadGameLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadGameLevel()
    {
        yield return new WaitForSeconds(15);
        Application.LoadLevel("GameScene");
    }

    public void SkipScene()
    {
        Application.LoadLevel("GameScene");
    }
}
