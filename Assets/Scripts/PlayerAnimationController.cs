using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnimationController
{
   public static class Params
    {
        public const string Vertical = nameof(Vertical);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string RunForeward = nameof(RunForeward);
        public const string RunBackward = nameof(RunBackward);
    }
}
