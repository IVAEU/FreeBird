using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Button nextBtn;
    public Button prevBtn;
    public Button startBtn;

    public Image playerImage;
    public List<Sprite> playerSprites = new List<Sprite>();
    private int _selectedIndex = 0;

    private void Start()
    {
        _selectedIndex = PlayerPrefs.GetInt("PlayerType", 0);
        
        nextBtn.onClick.AddListener(() =>
        {
            if (_selectedIndex + 1 < playerSprites.Count)
            {
                _selectedIndex++;
                RefreshImage();
            }
        });
        prevBtn.onClick.AddListener(() =>
        {
            if (_selectedIndex - 1 >= 0)
            {
                _selectedIndex--;
                RefreshImage();
            }
        });
        startBtn.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("PlayerType", _selectedIndex);
            SceneManager.LoadScene("PlayScene");
        });
        
        RefreshImage();
    }

    private void RefreshImage()
    {
        playerImage.sprite = playerSprites[_selectedIndex];
    }
}
