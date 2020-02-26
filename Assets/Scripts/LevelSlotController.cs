using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSlotController : MonoBehaviour, IPointerClickHandler
{
  private GameObject Menu;
  private GameObject Tower;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (Menu == null)
    {
      Menu = Instantiate(Resources.Load("Prefabs/LevelSlotMenu"), transform) as GameObject;
      Menu.GetComponent<LevelSlotMenuController>().Init(this, Tower);
    }
    else
    {
      OnMenuBuyClose();
    }
  }

  public void OnBuyTry(TowerData data)
  {
    if (Tower == null && AppController.I.UI.Withdraw(data.BuildPrice)) {
      Tower = Instantiate(Resources.Load("Prefabs/Tower"), transform) as GameObject;
      Tower.GetComponent<TowerController>().Init(data);      
      OnMenuBuyClose();
    }
  }

  public void OnSell(TowerData data)
  {
    AppController.I.UI.Gain(data.SellPrice);

    Tower.GetComponent<TowerController>().OnSell();

    OnMenuBuyClose();
  }

  private bool OnMenuBuyClose()
  {
    if (Menu != null)
    {
      Destroy(Menu);
      return true;
    }

    return false;
  }
}
