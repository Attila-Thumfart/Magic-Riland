using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Day, Income, Balance;

    public void UpdateEndOFDayUI()
    {
        Day.text = (GameManager.GMInstance.GetCalenderDay() - 1).ToString();
        Income.text = GameManager.GMInstance.GetDailyIncome().ToString();
        Balance.text = GameManager.GMInstance.GetPlayerMoney().ToString();
    }
}
