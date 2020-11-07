using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    public static Ball Instance { get; private set; }
    public float X_Distance { get; private set; }
    public ParabolicData parabolicData;
    private Vector2 velocity;
    private Rigidbody2D rb;
    #region Class
   
   
    public void StartSimulation(ParabolicData parabolicData)
    {
        rb.simulated = true;
        this.parabolicData = parabolicData;
        velocity = MyPhysicsManager.AngleVelocity2Vector(parabolicData);
    }
    private bool WouldEndSimulation => rb.simulated && rb.position.y < ushort.MinValue;
    private void CheckToEndSimulation()
    {
        if (WouldEndSimulation)
        {
            rb.simulated = !WouldEndSimulation;
            X_Distance = rb.position.x; //Cause x distances its equal to Xf - Xi, but Xi its equal to 0
            transform.position = new Vector3(transform.position.x, ushort.MinValue, ushort.MinValue);
            GameManager.Instance.Result();
        }
    }

  

    #endregion
    #region MonoBehaviour API
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        velocity.y += MyPhysicsManager.gravity * Time.fixedDeltaTime;
        rb.velocity = velocity;
        if (rb.simulated)
            CheckToEndSimulation();


    }
    #endregion
}
