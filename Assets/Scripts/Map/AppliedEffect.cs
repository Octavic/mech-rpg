
namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines an applied effect
    /// </summary>
    public class AppliedEffect
    {
        public Effects Effect{get;set;}
        public float Strength { get; set; }
        public float DurationLeft { get; set; }

        public AppliedEffect(Effects effect, float strength, float durationLeft)
        {
            this.Effect = effect;
            this.Strength = strength;
            this.DurationLeft = durationLeft;
        }

        /// <summary>
        /// Decays the effect
        /// </summary>
        /// <param name="deltaTime">How much time has passed</param>
        public void Decay(float deltaTime)
        {
            if (this.DurationLeft > 0)
            {
                this.DurationLeft -= deltaTime;
            }
        }

        /// <summary>
        /// If the effect should be removed
        /// </summary>
        /// <returns>True if the effect should be removed</returns>
        public bool ShouldRemove()
        {
            return this.DurationLeft <= 0;
        }
    }
}
