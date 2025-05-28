using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeBattleScene()
    {
        SceneManager.LoadScene("battle");
    }
    public void ChangeHomeScene()
    {
        SceneManager.LoadScene("home");
    }
    public void ChangeTitleScene()
    {
        SceneManager.LoadScene("title");
    }
}
