using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   #region Singletone

   public static GameManager Instance;

   private void Awake()
   {
      Instance = this;
   }

   #endregion

   #region Variable

   public enum GameState
   {
      menu, inGame, dead
   }

   public GameState currentGameState;
   [Header("Stats")]
   public int Score = 0;

   public int totalBonbon;
   public int currentGameBonbon;
   

   private void Start()
   {
      currentGameState = GameState.menu;
   }
   #endregion
}
