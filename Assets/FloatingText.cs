using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI floatingText;

    void Start()
    {
        //floatingText.text = Random.Range(1, 101).ToString();
        //floatingText.text = "wow";
    }

    private void Update() 
    {
        //this.transform.position = PlayerMovement.instance.position + Vector3.up * 3f;  
    }
    
}
