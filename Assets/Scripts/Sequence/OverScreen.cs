using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverScreen : MonoBehaviour
{
    [SerializeField] private Button titleBtn;

    private void Start()
    {
        titleBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("TitleScene");
        });
    }
}
