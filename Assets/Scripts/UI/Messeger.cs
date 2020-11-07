using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Messeger : MonoBehaviour
{
    public static Messeger Instance { get; private set; }

    public enum MessageType {Warning, Okey}

    public Button buttom;
    [SerializeField] private  GameObject visual;
    [SerializeField] private TextMeshProUGUI msg;
    [SerializeField] private Image icon;
    [SerializeField] private Sprite warningSprite;
    [SerializeField] private Sprite okeySprite;
    [SerializeField] private Color winColor;
    [SerializeField] private Color loseColor;
    #region Class logic
    public void ShowMessage(string value, MessageType messageType) 
    {

        if (messageType == MessageType.Okey)
        {
            icon.sprite = okeySprite;
            msg.color = winColor;
        }
        else 
        {
            icon.sprite = warningSprite;
            msg.color = loseColor;
        }
        visual.SetActive(true);
        msg.text = value;
    }
    #endregion
    #region MonoBehaviour API
    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
}
