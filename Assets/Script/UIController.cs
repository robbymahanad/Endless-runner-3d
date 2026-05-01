using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    private PlayerInput input;
    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
        input.MainMenu.Close.performed += Close_performed;
    }

    private void Close_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (closeButton != null && closeButton.gameObject.activeInHierarchy)
        {
            closeButton.onClick?.Invoke();
        }

    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void LoadSceneIndex(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
