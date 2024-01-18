using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detector : MonoBehaviour
{

    int player_1_score, player_2_score = 0;
    public Text j1_score;
    public Text j2_score;
    public Sounds sounds;

    

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
                sounds.pass();
                this.player_1_score++;

                if (this.player_1_score == 5) print("Winner: Player One");
            }
            else
            {
                this.player_2_score++;
                if (this.player_2_score == 5) print("Winner: Player One");
            }

            print("DEBUG: Player One: " + player_1_score + " | Player Two: " + player_2_score);

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
