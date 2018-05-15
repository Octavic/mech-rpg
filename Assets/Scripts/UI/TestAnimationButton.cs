
namespace Assets.Scripts.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Animations;

    public class TestAnimationButton : MonoBehaviour
    {
        public string TargetClip;
        public Animatable Target;

        public void PlayAnimation()
        {
            this.Target.PlayClip(TargetClip);
        }
    }
}
