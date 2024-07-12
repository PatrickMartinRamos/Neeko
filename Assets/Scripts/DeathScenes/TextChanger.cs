using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField]private int DeathCause; //1 Car ; 2 Sun
    private string[] deathLines = new string[6]
    {
        "Huwag nga sinabi tumawid! Nakakamatay!",
        "Oh sure, because sprinting across busy traffic lanes always seemed like a great idea. What could possibly go wrong?",
        "Who needs crosswalks and traffic signals? They’re clearly just suggestions for the faint of heart.",
        "I guess some people think they're invincible or maybe just really enjoy playing Frogger in real life.",
        "Jaywalking: because getting to the other side five seconds faster is totally worth risking your life for.",
        "Why use a perfectly safe pedestrian bridge when you can make a game out of dodging speeding cars?"
    };
    private string[] sunDried = new string[5]
    {
        "The risk of death increases the hotter you get and the longer you are overheated. (Healthdirect Australia, 2022)",
        "Heatstroke needs immediate first aid to lower your body temperature as quickly as possible. If not, it can lead to organ damage and death. (Healthdirect Australia, 2022)",
        "Your physical condition is a major factor in coming down with heatstroke. As you take note of your environment, know your body and be sensitive to its condition. (Heatstroke Zero, n.d.)",
        "Understanding your present environment is very important for preventing heatstroke. (Heatstroke Zero, n.d.)",
        "Heatstroke can be prevented by paying attention. (Heatstroke Zero, n.d.)"
    };
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        if (DeathCause == 1)
        {
            int rand = Random.Range(0, 5);
            text.text = deathLines[rand];
        }
        else
        {
            int rand = Random.Range(0, 5);
            text.text = sunDried[rand];
        }
    }
}
