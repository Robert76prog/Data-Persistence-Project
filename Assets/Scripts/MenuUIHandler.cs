using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerNameText.text = DataManager.Instance.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNew()
    {
        if (playerNameText.text != null )
        {
            DataManager.Instance.PlayerName = playerNameText.text;
            SceneManager.LoadScene(1);
        }
    }
 
}
