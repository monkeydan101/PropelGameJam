using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class deathScreen : MonoBehaviour
{
    public GameObject deathPanel;

    public TextMeshProUGUI dayCount;
    public TextMeshProUGUI essenseCount;
    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerDeath(int essenseCountInt, int dayCountInt)
    {
        deathPanel.SetActive(true);

        dayCount.text = dayCountInt.ToString();
        essenseCount.text = essenseCountInt.ToString();

    }
}
