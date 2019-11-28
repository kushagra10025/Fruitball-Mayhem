using System;

public class HealthSystem
{
    public event EventHandler onHealthChanged;
    private float health;
    private float healthMax;
    public HealthSystem(float healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (health)/ healthMax;
    }

    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
            health = 0;

        if (onHealthChanged != null)
        {
            onHealthChanged(this,EventArgs.Empty);
        }
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > healthMax)
            health = healthMax;
        
        
        if (onHealthChanged != null)
        {
            onHealthChanged(this,EventArgs.Empty);
        }
    }
}