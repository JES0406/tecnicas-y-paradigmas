using System.Reflection;

namespace Practica3
{
    public abstract class Obstacle
    {
        public bool pursuing { get; set; }
        public bool solid { get; }
        public int damage { get; }
        public float speedMultiplier { get; }
        public float debuffDuration { get; }

        protected Obstacle(bool pursuing, bool solid, int damage, float speedMultiplier, float debuffDuration)
        {
            this.pursuing = pursuing;
            this.solid = solid;
            this.damage = damage;
            this.speedMultiplier = speedMultiplier;
            this.debuffDuration = debuffDuration;
        }

        public override string ToString()
        {
            return "Obstacle";
        }
    }
    public class PoliceCar: Obstacle
    {
        public PoliceCar() : base(true, true, 30, 0.8f, 1)
        {
        }

        public override string ToString()
        {
            return "Police car";
        }
    }
    public class CosntructionFence : Obstacle
    {
        public CosntructionFence() : base(false, true, 10, 0.8f, 1)
        {
        }

        public override string ToString() {
            return "Construction fence";
        }
    }
    public class Debuff: Obstacle
    {
        public Debuff() : base(false, false, 0, 0.5f, 30)
        {
        }

        public override string ToString()
        {
            return "Debuff";
        }
    }
    public enum ObstacleType
    {
        PoliceCar,
        ConstructionFence,
        Debuff
    }
}
