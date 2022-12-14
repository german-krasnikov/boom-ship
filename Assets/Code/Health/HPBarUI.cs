using UnityEngine;
using UnityEngine.UI;

namespace Code.Health
{
  public class HPBarUI : MonoBehaviour
  {
    public Image ImageCurrent;

    public void SetValue(float current, float max)
    {
      ImageCurrent.fillAmount = current / max;
    }
  }
}
