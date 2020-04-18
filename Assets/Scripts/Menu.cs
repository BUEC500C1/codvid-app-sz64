using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CountryData ()
    {
        SceneManager.LoadScene("CountryData");
    }
    public void Map ()
    {
        SceneManager.LoadScene("Map");
    }
    public void Quit ()
    {
        Application.Quit();
    }
    public void Back ()
    {
        SceneManager.LoadScene("Main");
    }
}
