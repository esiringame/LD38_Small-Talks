using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextBoxManager : MonoBehaviour {

    public Text theText;
    public TextAsset textFile;

    private string[] textLines;
    private int currentLine;
    private int endAtLine;

    // Use this for initialization
    void Start()
    {

        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }
        endAtLine = textLines.Length;
    }

    private void Update()
    {
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
            if (currentLine == endAtLine)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
