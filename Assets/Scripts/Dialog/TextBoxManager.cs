using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class TextBoxManager : MonoBehaviour {

    public Text theText;
    private string allTextInFile;
    public PlayerBehaviour player;
    private string[] textLines;
    private int currentLine;
    private int endAtLine;
    public bool isActive;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void talkTriggered(int enemyIndex)
    {
        gameObject.SetActive(true);

        StreamReader theReader;
        if (enemyIndex == 1)
        {
            theReader = new StreamReader("Assets/Naration/Quentin.txt", Encoding.Default);
            allTextInFile = theReader.ReadToEnd();
        }
        else if (enemyIndex == 2)
        {
            theReader = new StreamReader("Assets/Naration/Fred.txt", Encoding.Default);
            allTextInFile = theReader.ReadToEnd();
        }
        else
        {
            theReader = new StreamReader("Assets/Naration/Else.txt", Encoding.Default);
            allTextInFile = theReader.ReadToEnd();
        }
        if (allTextInFile != null)
        {
            currentLine = 0;
            textLines = allTextInFile.Split('\n');
            endAtLine = textLines.Length;
        }
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
                isActive = false;
                player.OnRelease();
            }
        }
    }
}
