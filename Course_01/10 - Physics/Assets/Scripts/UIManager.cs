using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button roundButton;   
    public TMP_Text text;
   
    private PlayerController playerScript;

    private void Update()
    {
        text.text = "Papers: " + playerScript.coinAmount;
    }


}
