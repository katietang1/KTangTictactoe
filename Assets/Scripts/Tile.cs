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

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    private void OnMouseUp()
    {
        owner = tileManager.CurrentPlayer;
        if (owner == TileManager.Owner.Sword)
    
            this.GetComponent<SpriteRenderer>().color = Color.magenta;

        else if (owner == TileManager.Owner.Shield)
            this.GetComponent<SpriteRenderer>().color = Color.green;

        tileManager.ChangePlayer();
    }

    public void BackToWhite()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
