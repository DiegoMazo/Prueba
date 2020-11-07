using UnityEngine;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour
{
    [SerializeField] private InputValidator[] validators;
    [SerializeField] private Button startSimulationButtom;

    #region Class logic
    private void ValidateAll()
    {
        foreach (InputValidator validator in validators)
            if (validator.IsNullOrEmpty())
                return;
        StartSimulation();
    }

    private void StartSimulation()
    {
        gameObject.SetActive(false);
        SetBallParabolicData();
    }

    private void SetBallParabolicData()
    {
        float initialVelocity = validators[ushort.MinValue].value;
        float angle = validators[1].value;
        float playerDistance = validators[2].value;
        Ball.Instance.StartSimulation(new ParabolicData(initialVelocity, angle));
        GameManager.Instance.PlayerDistance = playerDistance;
    }
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        startSimulationButtom.onClick.AddListener(ValidateAll);
    }
    #endregion

}
