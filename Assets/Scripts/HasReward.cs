using UnityEngine;

public class HasReward : MonoBehaviour
{
    [SerializeField] private float rewardAmount = 1f;
    public void GiveReward()
    {
        FindObjectOfType<GoldManager>().AddGold(rewardAmount);
    }
}

