using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndOfDayRandomNumbers : MonoBehaviour
{
    [SerializeField]
    protected GameObject EndOfDayUI;

    [SerializeField]
    protected TMP_Text Score1;

    private GameManager GM;
    /*
    [SerializeField]
    protected TMP_Text Score2;

    [SerializeField]
    protected TMP_Text Score3;

    [SerializeField]
    protected TMP_Text Score4;
    */
    // Start is called before the first frame update
    public void Start()
    {
        if (EndOfDayUI.activeSelf)
        {
            GM = GameManager.GMInstance;

            /*     int rng1 = Random.Range(1, 11);
                 int rng2 = Random.Range(11, 21);
                 int rng3 = Random.Range(22, 31);
                 int rng4 = Random.Range(33, 41);


                 Score2.text = rng2.ToString();
                 Score3.text = rng3.ToString();
                 Score4.text = rng4.ToString();*/
            Score1.text = ("Summary of Day " + (GameManager.GMInstance.GetCalenderDay() - 1).ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
