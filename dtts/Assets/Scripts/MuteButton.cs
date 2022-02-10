using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    bool isMuted;
    public Sprite mutedButton;
    public Sprite unmutedButton;

    public void Mute()
    {
        if (isMuted)
        {
            isMuted = false;
            GetComponent<Image>().sprite = unmutedButton;
            AudioListener.volume = 1;
        }
        else
        {
            isMuted = true;
            GetComponent<Image>().sprite = mutedButton;
            AudioListener.volume = 0;
        }
    }
}
