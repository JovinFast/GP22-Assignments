using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TMP_Text coins;
    public TMP_Text lives;
    [SerializeField]
    StatsHandler statsHandler;
    private void Update()
    {
        lives.text = "LIVES: " + statsHandler.playerHP;
        coins.text = ""+statsHandler.coins;
    }
}
