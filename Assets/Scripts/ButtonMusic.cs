using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    public AudioSource enterButton;
    public AudioSource clickOnButton;

    public void EnterSound()
    {
        enterButton.Play();
    }

    public void ClickSound()
    {
        clickOnButton.Play();
    }
}
