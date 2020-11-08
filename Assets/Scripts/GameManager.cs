using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float PlayerDistance { get; set; }

    private const float maxErrorPercentAllowed = 0.5f;
    private const float oneHundred = 100;

    private const string victoryText = "Felicitaciones";
    private const string failText = "La distancia ingresada no es correcta";

    #region Class logic

    public void Result()
    {
        float fivePercent = Ball.Instance.X_Distance == ushort.MinValue ? maxErrorPercentAllowed : (5/oneHundred) * Ball.Instance.X_Distance;
        float minVale = Ball.Instance.X_Distance - fivePercent;
        float maxValue = Ball.Instance.X_Distance + fivePercent;

        Messeger.Instance.buttom.onClick.AddListener(ReloadGame);

        if (!(PlayerDistance >= minVale && PlayerDistance <= maxValue))
            Messeger.Instance.ShowMessage(failText, Messeger.MessageType.Warning);
        else
            Messeger.Instance.ShowMessage(victoryText, Messeger.MessageType.Okey);
    }

    public void ReloadGame() => SceneManager.LoadScene(ushort.MinValue);

    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
}
