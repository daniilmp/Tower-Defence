using UnityEngine;

public class HasReward : MonoBehaviour, IHasReward
{
    [SerializeField] private float rewardAmount = 1f;
    public void GiveReward()
    {
        FindObjectOfType<GoldManager>().AddGold(rewardAmount);
    }
}

