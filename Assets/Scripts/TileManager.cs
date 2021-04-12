/*
Name: Katie Tang
Student ID#: 2313452
Chapman email: htang@chapman.edu
Course Number and Section: 236-03
Assignment: Project06 3 x 3 TicTacToe
This is my own work, and I did not cheat on this assignment.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];
    public GameObject ButtonReset;
    public GameObject ButtonQuit;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;
    private Text SwScoreText;
    private Text ShScoreText;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        SwScoreText = GameObject.Find("SwordScoreText").GetComponent<Text>();
        ShScoreText = GameObject.Find("ShieldScoreText").GetComponent<Text>();
        ButtonReset.SetActive(false);
        ButtonQuit.SetActive(false);
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;

        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner() // rows and diagonals
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            ButtonReset.SetActive(true);
            ButtonQuit.SetActive(true);

            if (CurrentPlayer == Owner.Sword)
            {
                SwScoreText.GetComponent<SwordScoreController>().SwScore += 1;
                SwScoreText.GetComponent<SwordScoreController>().UpdateSwordScore();
               
            }
            else if (CurrentPlayer == Owner.Shield)
            {
                ShScoreText.GetComponent<ShieldScoreController>().ShScore += 1;
                ShScoreText.GetComponent<ShieldScoreController>().UpdateShieldScore();     
            }

            CurrentPlayer = Owner.None;
            return true;
        }

        return false;
    }
    public void ResetTiles()
    {
        for (int i = 0; i < 9; i++)
        {
            Tiles[i].BackToWhite();
            Debug.Log("Reset" + i);
        }
        Debug.Log("Resetting game");
        CurrentPlayer = Owner.Sword;
       // won = false;
        ButtonReset.SetActive(false);
        ButtonQuit.SetActive(false);
    }
    
    public void QuitGame()
    {
        Debug.Log("Game quit, goodbye.");
        Application.Quit();
    }

}
