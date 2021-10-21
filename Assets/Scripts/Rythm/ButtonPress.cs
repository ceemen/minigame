using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    private RawImage buttonImage;
    public Texture button;
    public Texture buttonPressed;

    public KeyCode keyPress;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<RawImage>();
        buttonImage.texture = button;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyPress))
        {
            buttonImage.texture = buttonPressed;
        }
        if (Input.GetKeyUp(keyPress))
        {
            buttonImage.texture = button;
        }

    }
}
