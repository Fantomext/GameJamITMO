using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnPress : MonoBehaviour
{
    public int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            LoadGame();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(levelIndex);
        Destroy(gameObject);
    }
}
