using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    private Player _player;

    private void Start()
    {
        _player = Player.Instance;
        _player.OnMoneyChange += ChangeMoneyText;
    }

    private void OnDisable()
    {
        _player.OnMoneyChange -= ChangeMoneyText;
    }

    private void ChangeMoneyText(float money)
    {
        if (money < 1000)
            _moneyText.text = money.ToString();
        else if (money >= 1000 && money < 1000000)
            _moneyText.text = string.Format("{0:0.00k}",(money / 1000f));
        else if (money >= 1000000 && money < 1000000000)
            _moneyText.text = string.Format("{0:0.00M}", (money / 1000000f));
        else
            _moneyText.text = string.Format("{0:0.00B}", (money / 1000000000f));
    }
}
