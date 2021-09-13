using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class S_LevelSelectMenu : MonoBehaviour
{
    int textValue;
    string textNumber;

    public void selectLevel(GameObject button)
    {
        textNumber = button.transform.GetChild(0).GetComponent<Text>().text;
        int.TryParse(textNumber, out textValue);
        SceneManager.LoadScene(textValue);
    }
}
