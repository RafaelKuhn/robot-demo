using UnityEngine;

public class SignalLight : MonoBehaviour
{
    [SerializeField] Light pointLight;
    [SerializeField] Renderer lightRenderer;

	private MaterialPropertyBlock materialProperties;

	private int emissionID = Shader.PropertyToID("_EmissionColor");

	void Awake()
	{
		materialProperties = new MaterialPropertyBlock();
	}

	public void SignalWithColorColor(Color col)
	{
        pointLight.color = col;
		pointLight.intensity = 2f;

		lightRenderer.GetPropertyBlock(materialProperties, 0);
		materialProperties.SetVector(emissionID, new Vector4(col.r, col.g, col.b, 1f));
		lightRenderer.SetPropertyBlock(materialProperties);
	}

	public void TurnSignalOff()
	{
		pointLight.intensity = 0f;

		lightRenderer.GetPropertyBlock(materialProperties, 0);
		materialProperties.SetVector(emissionID, new Vector4(0f, 0f, 0f, 1f));
		lightRenderer.SetPropertyBlock(materialProperties);
	}
}
