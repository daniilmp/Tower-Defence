using UnityEngine;

public class HasReward : MonoBehaviour, IHasReward
{
    [SerializeField] private float rewardAmount = 1f;

    private IPlayerGold _playerGold;
    public void GiveReward()
    {
        _playerGold.AddGold(rewardAmount);
    }
    public void Initialize(IPlayerGold playerGold)
    {
        _playerGold = playerGold;
    }
}

