using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
namespace InputReader
{
    public class GameUIInputReader : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _jumpButton;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _inventoryButton;

        public float Direction => _joystick.Horizontal;

        public bool Jump { get; private set; }
        public bool Attack { get; private set; }

        private void Awake()
        {
            _jumpButton.onClick.AddListener(call: () => Jump = true);
            _attackButton.onClick.AddListener(call: () => Attack = true);
        }

        private void OnDestroy()
        {
            _jumpButton.onClick.RemoveAllListeners();
            _attackButton.onClick.RemoveAllListeners();
        }

        public void ResetOneTimeActions()
        {
            Jump = false;
            Attack = false;
        }
    }
}