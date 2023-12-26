
using UnityEngine;

public class AddGold : MonoBehaviour
{
    [SerializeField] private Health _Gold;
    [SerializeField] private Recovery _recovery;
    [SerializeField] private PlayerInput _input;
   
    private void Start()
    {
        _Gold.OnDead += HandleOnDie;
        _recovery.OnRecover += SubtractGold;
    }
    public void OnDestroy()
    {
        _Gold.OnDead -= HandleOnDie;
        _recovery.OnRecover -= SubtractGold;
    }

    private void HandleOnDie()
    {
        Currency softCurrency = Context.Instance.CurrencySystem.SoftCurrency;
        int randomAmount = UnityEngine.Random.Range(5, 25);
        softCurrency.Amount += randomAmount;
    }

    private void SubtractGold()
    {
        Currency softCurrency = Context.Instance.CurrencySystem.SoftCurrency;
        int gold = 10;
        
        if (softCurrency.Amount >= gold)
        {
            softCurrency.Amount -= gold;
            _input.isHpdSlotEmpty = true;
        }
        else
        {
            Debug.LogWarning("Недостатньо голди для віднімання.");
        }
    }
    
}
