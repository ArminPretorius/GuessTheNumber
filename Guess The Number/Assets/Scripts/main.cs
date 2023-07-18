using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class main : MonoBehaviour
{
    public int randInt = 0;
    public int life = 3;
    public TMP_InputField inpText;
    public TextMeshProUGUI lifeText;
    public GameObject pnlNotification;
    public TextMeshProUGUI strNotification;


    void Start()
    {
        Reset();
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");
        if (randInt == int.Parse(inpText.text))
        {
            strNotification.text = "Correct!";
            pnlNotification.SetActive(true);
            StartCoroutine(waiter());
            Reset();
        }
        else
        {
            life--;
            if (life == 0)
            {
                strNotification.text = "Incorrect, Game Over!";
                pnlNotification.SetActive(true);
                StartCoroutine(waiter());
                Reset();
            }
            else
            {
                strNotification.text = "Incorrect!";
                pnlNotification.SetActive(true);
                StartCoroutine(waiter());
            }
            lifeText.text = ""+life;
        }
    }

    public void Reset()
    {
        randInt = Random.Range(0, 101);
        life = 3;
        lifeText.text = ""+life;
        inpText.text = "";
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        pnlNotification.SetActive(false);
    }
}
