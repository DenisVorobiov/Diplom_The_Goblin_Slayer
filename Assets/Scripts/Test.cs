using System.Collections;
using UnityEditor.Timeline;
using UnityEngine;

public class Test : MonoBehaviour
{
    [ContextMenu("AddScoreTest")]
    public void AddScoreTest ()
    {
        Context.Instance.ScoreSystem.AddScore(100);
    }
}