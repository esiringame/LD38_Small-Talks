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

    public void talkTriggered(int CharacterId, int EncounterCounter)
    {
        gameObject.SetActive(true);
        EncounterCounter++;
        StreamReader theReader;
        if (EncounterCounter > 3 || CharacterId > 8)
        {
            theReader = new StreamReader("Assets/Naration/Random.txt", Encoding.UTF8);
            allTextInFile = theReader.ReadToEnd();
        }
        else if (EncounterCounter <  3 && CharacterId > 0)
        {
            theReader = new StreamReader("Assets/Naration/"+ CharacterId.ToString() + EncounterCounter.ToString() + ".txt", Encoding.UTF8);
            allTextInFile = theReader.ReadToEnd();
        }
        else 
        {
            Debug.Log("CharacterId is wrong, 0 is for generic pedestrian");
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
