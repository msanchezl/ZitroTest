using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text titleText;

    public List<GameObject> gamePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        int game = LobbyManager.gameSelected + 1; 
        titleText.text = "Juego " + game;

        Instantiate(gamePrefabs[LobbyManager.gameSelected], Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
