using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button startButton;

     private int currentPlayer;

    private void Start()
    {
        currentPlayer = SaveManager.instance.currentPlayer;
        SelectPlayer(currentPlayer);
    }

    private void SelectPlayer(int index)
    {
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }

        
    }

    public void ChangePlayer(int change)
    {
        currentPlayer += change;

        SaveManager.instance.currentPlayer = currentPlayer;
        SaveManager.instance.Save();
        SelectPlayer(currentPlayer);

    }

    public void startGame()
    {

        //SceneManager.LoadScene("UTAR classroom and lecture");
        SceneManager.LoadScene("Lobby");
       
    }
}
