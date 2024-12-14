using System;
using UnityEngine;

namespace ProjectI.Game.Player
{
    [Serializable]
    public class MoveSettings
    {
        [SerializeField] private float defaultMoveSpeed;
        [SerializeField] private float acceleration = 10f;
        [SerializeField] private float deceleration = 50f;
        [SerializeField] private float fallMoveSpeed;
        [SerializeField] private float defaultJumpCount;
        [SerializeField] private float jumpForce;
        [SerializeField] private float groundHeight;

        public float DefaultMoveSpeed => defaultMoveSpeed;

        public float DefaultJumpCount => defaultJumpCount;

        public float JumpForce => jumpForce;

        public float GroundHeight => groundHeight;

        public float FallMoveSpeed => fallMoveSpeed;

        public float Acceleration => acceleration;

        public float Deceleration => deceleration;
    }
}