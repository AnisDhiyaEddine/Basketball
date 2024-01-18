using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{

    int player_1_score, player_2_score = 0;
    public Text j1_score;
    public Text j2_score;
    public Text winner;
    public AudioSource src;
    public AudioClip passSrc;
    public DisplayMenu winningCanvas;


    int activePlayer = 1;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            if (activePlayer == 1)
            {
                src.clip = passSrc;
                src.Play();
                this.player_1_score++;
                this.j1_score.text = "J1 Score : " + this.player_1_score + "/5";
                if (this.player_1_score == 1)
                {
                    winner.text = "J1 Won";
                    print("Winner: Player One");
                    winningCanvas.ToggleMenu();
                    //winningCanvas.playing = false;
                }
            }
            else
            {
                this.player_2_score++;
                this.j2_score.text = "J2 Score : " + this.player_2_score + "/5";
                if (this.player_2_score == 5)
                {
                    winner.text = "J2 Won";
                    print("Winner: Player One");
                    winningCanvas.ToggleMenu();
                    //winningCanvas.playing = false;
                }
            }

            print("DEBUG: Player One: " + this.player_1_score + " | Player Two: " + this.player_2_score);

            if (this.player_1_score >= 5 || this.player_2_score >= 5)
            {
                print("Game restarted !");
                this.player_1_score = this.player_2_score = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
