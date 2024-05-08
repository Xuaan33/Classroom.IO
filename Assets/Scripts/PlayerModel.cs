using UnityEngine;
using Photon.Pun;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    private void Awake()
    {
       
            ChoosePlayer(SaveManager.instance.currentPlayer);
        
        
    }

    private void ChoosePlayer(int index)
    {
         Instantiate(players[index], transform.position, Quaternion.identity, transform); 
        //(player, spawn position, xy rotation, parent)
    }
}
