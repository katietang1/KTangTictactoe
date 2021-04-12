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

public class ShieldScoreController : MonoBehaviour
{
    public int ShScore = 0;

    public void UpdateShieldScore()
    {
        GetComponent<Text>().text = "Shield: " + ShScore;
    }
}