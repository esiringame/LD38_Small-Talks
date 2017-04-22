using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;
    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    protected int endAtLine;

    //public PlayerController player;

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
                textBox.SetActive(false);
            }
        }
    }
}
