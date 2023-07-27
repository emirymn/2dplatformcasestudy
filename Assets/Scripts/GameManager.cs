using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool canSpawnObstaccle;
    public bool canMove = true;
    public bool isGrounded;
    
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    public IEnumerator RestartTheGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
