using System.Collections;
using UnityEngine;
using TMPro;

public class CartesianDrawer : MonoBehaviour
{
    // Draws a line from "startVertex" var to the curent mouse position.
    private int gridSize = 200;
    [SerializeField] private Material mat;
    [SerializeField] private TextMeshProUGUI playerCoords;

    private const float refreshTime = 0.04f;
    private IEnumerator CShowPlayerCoords()
    {
        do
        {
            playerCoords.text = Ball.Instance.transform.position.ToString();
            yield return new WaitForSeconds(refreshTime);
        } while (true);
    }

    private void Start()
    {
        StartCoroutine(CShowPlayerCoords());
    }

    private void OnPostRender()
    {


        GL.Begin(GL.LINES);
        mat.SetPass(0);
        for (int i = -gridSize; i < gridSize; i++)
        {
            GL.Vertex3(i, -gridSize, ushort.MinValue);
            GL.Vertex3(i, gridSize, ushort.MinValue);
        }
        for (int i = -gridSize; i < gridSize; i++)
        {
            GL.Vertex3(-gridSize, i, ushort.MinValue);
            GL.Vertex3(gridSize, i, ushort.MinValue);
        }
        GL.End();
    }
}
