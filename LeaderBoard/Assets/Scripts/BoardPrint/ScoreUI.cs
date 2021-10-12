using Game;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class ScoreUI : MonoBehaviour
    {
        public RowUI rowUi;
        public ScoreManager scoreManager;
        void Start(){
           scoreManager.AddScore(new Score("G", ScrAnimController.fruitEaten+1));
           scoreManager.AddScore(new Score("A", ScrAnimController.fruitEaten + 2));
           scoreManager.AddScore(new Score("Q", ScrAnimController.fruitEaten+3));
           var scores = scoreManager.GetHighScore().ToArray();
            for (int i = 0; i < scores.Length; i++)
            {
                var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
                row.Rank.text = (i + 1).ToString();
                row.name.text = scores[i].name;
                row.score.text = scores[i].score.ToString();
            }
        }
    void Update()
    {
        scoreManager.AddScore(new Score("G", ScrAnimController.fruitEaten));
        scoreManager.AddScore(new Score("A", ScrAnimController.fruitEaten));
        scoreManager.AddScore(new Score("Q", ScrAnimController.fruitEaten));
    }

}


