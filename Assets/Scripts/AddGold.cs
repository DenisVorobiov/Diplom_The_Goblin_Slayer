
using UnityEngine;

public class AddGold : MonoBehaviour
{
    [SerializeField] private Health _Gold;
   
    private void Start()
    {
        _Gold.OnDead += HandleOnDie;
    }
    public void OnDestroy()
    {
        _Gold.OnDead -= HandleOnDie;
    }

    private void HandleOnDie()
    {
        Currency softCurrency = Context.Instance.CurrencySystem.SoftCurrency;
        int randomAmount = UnityEngine.Random.Range(5, 25);
        softCurrency.Amount += randomAmount;
        
    }
    
}
