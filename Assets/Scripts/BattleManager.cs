using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private List<Figther> _fighters = new List<Figther>();
    [SerializeField]
    private int _fightersNeededToStart = 2;
    [SerializeField]
    private UnityEvent _onBattleStarted;
    [SerializeField]
    private UnityEvent _onBattleEnded;
    private Coroutine _battleCoroutine;
    public void AddFighter(Figther figther)
    {
        _fighters.Add(figther);
        if (_fighters.Count >= _fightersNeededToStart)
        {
            StartBattle();
        }
    }
    public void RemoveFighter(Figther figther)
    {
        _fighters.Remove(figther);
        if (_battleCoroutine != null)
        {
            StopCoroutine(_battleCoroutine);
        }
        
    }
    private void InitializeFighters()
    {
        foreach (var figther in _fighters)
        {
            figther.InitializeFighter();
        }
    }
    public void StartBattle()
    {
        InitializeFighters();
        _battleCoroutine = StartCoroutine(BattleCoroutine());
    }
    private IEnumerator BattleCoroutine()
    {
        _onBattleStarted?.Invoke();
        while (_fighters.Count >= 1)
        {
            Figther attacker = _fighters[Random.Range(0, _fighters.Count)];
            Figther defender = _fighters[Random.Range(0, _fighters.Count)];
            attacker.transform.LookAt(defender.transform);
            defender.transform.LookAt(attacker.transform);
            while (defender == attacker)
            {
                defender = _fighters[Random.Range(0, _fighters.Count)];
            }
            Attack attack = attacker.AttackData.attacks[Random.Range(0, attacker.AttackData.attacks.Length)];
            float damage = Random.Range(attack.minDamage, attack.maxDamage);
            attacker.CharacterAnimator.Play(attack.animationName);
            yield return new WaitForSeconds(attack.attackDuration);
            defender.Healt.TakeDamage(damage);
            if (defender.Healt.CurrentHealth <= 0)
            {
                RemoveFighter(defender);
            }
        }
        _onBattleEnded?.Invoke();
    }
}
