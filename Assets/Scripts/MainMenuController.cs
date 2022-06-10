using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Created By FX Mario Jevta - 149251970101-23");
        SceneManager.LoadScene("Game");
    }
}
