using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class UIController : MonoBehaviour
{
  public TextMeshProUGUI TextWave;
  public TextMeshProUGUI TextCoins;
  public TextMeshProUGUI TextHealth;

  private int Wave = 0;
  private int Coins = 100;
  private int Health = 100;

  public void SetWave(int wave)
  {
    Wave = wave;
    UpdateWave();
  }

  public bool Withdraw(int amount)
  {
    if (Coins >= amount)
    {
      Coins -= amount;
      UpdateCoins();

      return true;
    }

    return false;
  }

  public void Gain(int amount)
  {
    Coins += amount;
    UpdateCoins();
  }

  public void Damage(int amount)
  {
    if (Health > 0 && Health >= amount)
    {
      Health -= amount;
    }
    else
    {
      Health = 0;
      //  TODO: handle loose
    }

    UpdateHealth();    
  }

  private void Start()
  {
    UpdateCoins();
    UpdateHealth();
  }

  private void UpdateWave()
  {
    TextWave.text = "Wave: " + Wave + "/" + AppController.I.Waves.Length;
  }

  private void UpdateCoins()
  {
    TextCoins.text = "Coins: " + Coins;
  }

  private void UpdateHealth()
  {
    TextHealth.text = "Health: " + Health;
  }
}
