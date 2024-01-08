using UnityEngine;
using UnityEngine.UI;

public class ScratchDemoUI : MonoBehaviour
{
	public ScratchCardManager CardManager;
	public EraseProgress EraseProgress;

	void Start()
	{
        EraseProgress.OnProgress += OnEraseProgress;
    }
    float prograssf;
	public void Restart()
	{
        CardManager.ResetScratchCard();

    }
    public float GetPrograss()
    {
        return prograssf;
    }

	public void OnEraseProgress(float progress)
	{
        prograssf = progress * 100f;
	}
}