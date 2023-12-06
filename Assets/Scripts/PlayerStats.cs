
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class PlayerStatsStorage : ScriptableObject
{
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float playerHeight;
    
    public float multiplication = 10;
    public float playerPercentage = 0.2f;
    public float playerPercentagePlus = 0.3f;
}
