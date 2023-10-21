using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField, HideInInspector] int currHealth;

    [SerializeField]
    private InterfaceUI interfaceUI;

    private void Start()
    {
        currHealth = maxHealth;
        interfaceUI.ChangeHpBar(currHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        interfaceUI.ChangeHpBar(currHealth, maxHealth);
        if (currHealth < 0)
        {
            Die();
        }
        print(currHealth);
    }

    public void Heal(int heal)
    {
        currHealth += heal;
        interfaceUI.ChangeHpBar(currHealth, maxHealth);
    }

    public void Die()
    {
        Debug.Log("die");
    }
}
