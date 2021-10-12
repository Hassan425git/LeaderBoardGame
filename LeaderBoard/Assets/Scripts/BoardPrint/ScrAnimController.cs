using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class ScrAnimController : MonoBehaviour
    {
        public Animator anim;
        public GameObject[] fruit;
        public static int fruitEaten = 0;
        public ScoreManager scoreManager;

        void Start()
        {
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            int fruitEaten = 0;
            for (int i = 0; i < fruit.Length; i++)
            {
                if (!fruit[i])
                {
                    fruitEaten++;
                    scoreManager.AddScore(new Score("H", ScrAnimController.fruitEaten));
                    scoreManager.AddScore(new Score("A", ScrAnimController.fruitEaten++));
                }
            }
            if (fruitEaten == fruit.Length)
            {
                anim.Play("doorAnimation");
            }

           
        }
    }
}