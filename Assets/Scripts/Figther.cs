using UnityEngine;
using UnityEngine.Events;

public class Figther : MonoBehaviour
{
    [SerializeField]
    private string _fighterNane;
    public string FigtherName => _fighterNane;
    [SerializeField]
    private AttackData _attackData;
    public AttackData AttackData => _attackData;
    [SerializeField]
    private Healt _health;
    public Healt Healt => _health;
    [SerializeField]
    private Animator _characterAnimator;
    public Animator CharacterAnimator => _characterAnimator;
    [SerializeField]
    private UnityEvent _onInitialize;
    public void InitializeFighter()
    {
        _onInitialize?.Invoke();
    }
}
