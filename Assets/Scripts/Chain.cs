using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chain : MonoBehaviour
{

    public int chainDurability;
    public TextMeshProUGUI durabilityText;

    private void Awake()
    {
        durabilityText.text = chainDurability.ToString();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        chainDurability--;
        durabilityText.text = chainDurability.ToString();
        if (chainDurability <= 0)
        {
            Destroy(gameObject);
        }
    }


}
