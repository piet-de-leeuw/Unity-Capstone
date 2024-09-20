using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    int score = 0;

    void Start()
    {
        text.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 50;
            Destroy(other.transform.root.gameObject);
        }

        text.text = score.ToString();

    }

}
