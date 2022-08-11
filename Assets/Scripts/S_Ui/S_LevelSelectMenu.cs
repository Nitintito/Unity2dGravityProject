using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_LevelSelectMenu : MonoBehaviour
{
    int textValue;
    string textNumber;
    public static int unlockedLevels = 1;
    [SerializeField] private GameObject LevelButtons;

    private void Awake()
    {
        LevelColor();
    }

    public void SelectLevel(GameObject button)
    {
        textNumber = button.transform.GetChild(0).GetComponent<Text>().text;
        int.TryParse(textNumber, out textValue);

        if (textValue <= unlockedLevels)
        {
            SceneManager.LoadScene(textValue);
        }
        else
            Debug.Log("Level locked");
    }

    // Sets the color of a lvl button depending on if its unlockt or not.
    private void LevelColor()
    {
        for (int i = 0; i < LevelButtons.transform.childCount; i++)
        {
            if (i < unlockedLevels)
            {
                LevelButtons.transform.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            else
            {
                LevelButtons.transform.GetChild(i).GetComponent<Image>().color = Color.gray;
            }
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        unlockedLevels = 1;
        PlayerPrefs.SetInt("Unlocked Levels", unlockedLevels);
        LevelColor();
    }
}
