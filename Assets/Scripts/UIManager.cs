using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for UI

public class UIManager : MonoBehaviour
{

    // handle to text
    [SerializeField]
    private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        // assing text tp the handle
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }



}
