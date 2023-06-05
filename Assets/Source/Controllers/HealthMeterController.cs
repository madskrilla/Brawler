using Assets.Source.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeterController : MonoBehaviour
{
    private PlayerController _player = null;
    [SerializeField]
    private bool DebugPanel = false;
    [SerializeField]
    private HealthDebugPanel _healthDebugPanel;
    [SerializeField]
    private Text _amountDisplayText;
    private HealthModel _healthModel;

    // Start is called before the first frame update
    void Start()
    {
#if DEBUG
        _healthDebugPanel._parent.SetActive(DebugPanel);
#endif
        _player = GameObject.FindObjectOfType<PlayerController>();
        _healthModel = new HealthModel(100, 0);
        _player.gameObject.GetComponent<HealthController>().Health.SubscribeToText(_amountDisplayText);

        _healthDebugPanel._reduceHealthButton.onClick.AsObservable().Subscribe(_ => _healthModel._health.Value -= 5);
        _healthDebugPanel._resetHealthButton.onClick.AsObservable().Subscribe(_ => _healthModel._health.Value = 100);
    }
}

public class HealthModel
{
    public IReactiveProperty<int> _armor;
    public IReactiveProperty<int> _health;

    public HealthModel(int health, int armor)
    {
       _health = new ReactiveProperty<int>(health);
    }
}

[Serializable]
public class HealthDebugPanel
{
    public GameObject _parent;
    public Button _reduceHealthButton;
    public Button _resetHealthButton;
}
