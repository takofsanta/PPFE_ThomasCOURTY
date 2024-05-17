using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoutonBeedback : MonoBehaviour
{
    public Color white;
    public Color over;
    public Color click;
    public RawImage background;

    SoupBehavior behavior;

    private void Over()
    {
        background.color = over;
    }

    private void Click()
    {
        background.color = click;
        behavior.clicSound();
    }

    private void Release()
    {
        background.color = white;
    }
}
