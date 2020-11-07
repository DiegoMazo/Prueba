using System.Collections;
using System.Collections.Generic;
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
        float delta = Ball.Instance.X_Distance - PlayerDistance;
        float percent = delta * Ball.Instance.X_Distance / oneHundred;
        Messeger.Instance.buttom.onClick.AddListener(ReloadGame);

        if (percent >= maxErrorPercentAllowed)
            Messeger.Instance.ShowMessage(failText, Messeger.MessageType.Warning);
        else
            Messeger.Instance.ShowMessage(victoryText, Messeger.MessageType.Okey);
    }

    public void ReloadGame() =>  SceneManager.LoadScene(ushort.MinValue);

    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
}
