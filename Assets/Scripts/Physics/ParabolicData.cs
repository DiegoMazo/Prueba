[System.Serializable]
public struct ParabolicData
{
    public float initialVelocity;
    public float angle;

    public ParabolicData(float initialVelocity, float angle) 
    {
        this.initialVelocity = initialVelocity;
        this.angle = angle;
    }
}
