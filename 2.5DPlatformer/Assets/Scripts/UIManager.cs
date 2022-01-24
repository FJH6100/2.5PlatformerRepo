using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _livesText;
    public void UpdateCoinDisplay(int coins)
    {
        _coinText.text = coins.ToString();
    }
    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = lives.ToString();
    }
}
