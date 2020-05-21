using UnityEngine;

public class HasReward : MonoBehaviour, IHasReward
{
    [SerializeField] private float rewardAmount = 1f;

    private PlayerGold _playerGold;
    public void GiveReward()
    {
        _playerGold.AddGold(rewardAmount);
    }
    public void Initialize(PlayerGold playerGold)
    {
        _playerGold = playerGold;
    }
}

