using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PsyanimTestCanvas : MonoBehaviour
{
    public List<string> scenes = new List<string>();

    public TextMeshProUGUI sceneNameTextField;

    private int _currentSceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

        handleSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);

        SceneManager.sceneLoaded += this.handleSceneLoaded;
    }

    void handleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneNameTextField.text = scenes[_currentSceneIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonDown(0))
        {
            _currentSceneIndex++;

            if (_currentSceneIndex == scenes.Count)
            {
                _currentSceneIndex = 0;
            }

            SceneManager.LoadScene(scenes[_currentSceneIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            _currentSceneIndex--;

            if (_currentSceneIndex < 0)
            {
                _currentSceneIndex = scenes.Count - 1;
            }

            SceneManager.LoadScene(scenes[_currentSceneIndex]);
        }
    }
}
