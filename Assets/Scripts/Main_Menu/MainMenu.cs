using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public void LoadGame() {
    // load the game scene
    Debug.Log("Yesy");
    SceneManager.LoadScene(1);
}
}
