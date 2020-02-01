using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFalloff : MonoBehaviour
{

    public Image img;

    public FloatData imgFalloff;

    public void Update()
    {
        img.fillAmount = imgFalloff.value;
    }
}
