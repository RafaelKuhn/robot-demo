using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Wall : MonoBehaviour
{
	[SerializeField] Material onLaseredMaterial;

	Renderer rend;
	Material startMaterial;

	void Awake()
	{
		rend = GetComponent<Renderer>();
		startMaterial = rend.sharedMaterial;
	}

	public void ApplyLaserMaterial()
	{
		rend.sharedMaterial = onLaseredMaterial;
	}

    public void ResetMaterial()
	{
		rend.sharedMaterial = startMaterial;
	}
    
}
