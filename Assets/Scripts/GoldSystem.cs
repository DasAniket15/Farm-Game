using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldSystem : MonoBehaviour
{
    public int gold;
    public Text goldText;

    void Update()
    {
        goldText.text = gold + "�";
    }
}
