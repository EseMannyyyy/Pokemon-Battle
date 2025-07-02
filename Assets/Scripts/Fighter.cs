using UnityEngine;
using UnityEngine.Events;

public class Fighter : MonoBehaviour
{
    [SerializeField]
    private string _fighterName;
    public string FighterName => _fighterName;
    [SerializeField]
    private AttackData _attackData;
    public AttackData AttackData => _attackData;
    [SerializeField]
    private Health _health;
    public Health Health => _health;
    [SerializeField]
    private Animator _characterAnimator;
    public Animator CharacterAnimator => _characterAnimator;
    [SerializeField]
    private UnityEvent _onInitialize;
    [SerializeField]
    private string _winAnimationName;
    public string WinAnimationName => _winAnimationName;
    [SerializeField]
    private string _winSoundName;
    public string WinSoundName => _winSoundName;
    public void InitializeFighter()
    {
        _onInitialize?.Invoke();
    }
}
