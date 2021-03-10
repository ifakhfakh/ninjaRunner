using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void Replay() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void nextScene() {
      SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
