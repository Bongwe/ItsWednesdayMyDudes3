using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public string sceneName;
    public AudioSource deathAudio;
    // Start is called before the first frame update
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // called when the cube hits the fxloor
    void OnCollisionEnter2D(Collision2D col)
    {
        deathAudio.Play();
        StartCoroutine("LoadNewLevel");

    }

    IEnumerator LoadNewLevel()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("GameOverScene");
    }

}
 