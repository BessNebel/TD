using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
  public string EnemyName;
  public Animator EnemyAnimator;

  public void Top()
  {
    EnemyAnimator.Play("Enemy" + EnemyName + "Top");    
  }

  public void Right()
  {
    EnemyAnimator.Play("Enemy" + EnemyName + "Right");    
  }

  public void Down()
  {
    EnemyAnimator.Play("Enemy" + EnemyName + "Down");    
  }

  public void Left()
  {
    EnemyAnimator.Play("Enemy" + EnemyName + "Left");    
  }
}
