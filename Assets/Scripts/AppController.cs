using UnityEngine;
using UnityEngine.U2D;

public class AppController : MonoBehaviour
{
  public static AppController Instance = null;

  public UIController UI;

  public SpriteAtlas Atlas;
  public LevelController Level;

  private void Start()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else if (Instance == this)
    {
      Destroy(gameObject);
    }
  }
}
