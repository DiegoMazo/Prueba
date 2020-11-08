using UnityEngine;
using TMPro;
using System.Globalization;

public class InputValidator : MonoBehaviour
{
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 90f;
    [HideInInspector] public float value;
    protected TMP_InputField inputField;

    private static string emptyFieldError = "No puedes dejar ningún campo vacío";
    private static string negativeSing = "-";



    #region Class Logic
    private void Validate(string text)
    {
        try
        {
            if (text.Contains(negativeSing))
            {
                inputField.text = string.Empty;
                return;
            }
            value = Mathf.Clamp(float.Parse(text, CultureInfo.InvariantCulture.NumberFormat), minValue, maxValue);
            inputField.text = value.ToString();
        }
        catch (System.Exception e)
        {
            print(e.ToString());
        }
    }

    public bool IsNullOrEmpty()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            Messeger.Instance.ShowMessage(emptyFieldError, Messeger.MessageType.Warning);
            return true;
        }
        return false;
    }
    #endregion

    #region MonoBehavior API
    private void Awake() => inputField = GetComponent<TMP_InputField>();
    private void Start() => inputField.onDeselect.AddListener((string text) => Validate(text));
    #endregion
}
