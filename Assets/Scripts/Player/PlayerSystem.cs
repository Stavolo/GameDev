using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputReader;
namespace Player
{
    public class PlayerSystem : MonoBehaviour
    {
        private readonly PlayerEntity _playerEntity;
        private readonly PlayerBrain _playerBrain;

        public PlayerSystem(PlayerEntity playerEntity, List<IEntityInputSource> inputSource)
        {
            _playerEntity = playerEntity;
            _playerBrain = new PlayerBrain(_playerEntity, inputSource);
        }
    }
}