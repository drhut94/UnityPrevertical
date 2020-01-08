using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorType : MonoBehaviour
{
    public enum color { ORANGE, BLUE}

    public static Color GetOrenge() {
        return new Color(255,97,29);
    }

    public static Color GetBlue() {
        return new Color(29, 206, 255);
    }

}
