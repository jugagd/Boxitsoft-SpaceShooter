using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.


        Text text;                      // Reference to the Text component.
        int record;

        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            score = 0;

            //Commented to reset the record score
            // PlayerPrefs.SetInt("Record", 0);    

            record = PlayerPrefs.GetInt("Record");
            text.color = Color.white;
            Cursor.visible = false;
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Score: " + score + " - Best:" + record;
            if (score>record)
            {
                record = score;
                PlayerPrefs.SetInt("Record", record);
                text.color = Color.green;

            }
        }
    }
}