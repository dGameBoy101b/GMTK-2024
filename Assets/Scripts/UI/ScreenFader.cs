using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScreenFader : MonoBehaviour
{
	[Tooltip("Whether this should astart in its fade out state")]
	public bool ShouldStartFadedOut;

	public UnityEvent OnFadeInStart = new UnityEvent();
	
	public UnityEvent OnFadeInEnd = new UnityEvent();
	
	public UnityEvent OnFadeOutStart = new UnityEvent();

	public UnityEvent OnFadeOutEnd = new UnityEvent();

	public Image Image { get; private set; }

	private Coroutine Transition = null;

	public bool IsTransitioning { get => this.Transition is not null; }

	public void FadeIn(float duration = 1f)
	{
		if (this.IsTransitioning)
		{
			this.StopCoroutine(this.Transition);
		}
		this.Transition = this.StartCoroutine(this.Fade(1, duration, this.OnFadeInStart, this.OnFadeInEnd));
	}

	public void FadeOut(float duration = 1f)
	{
		if (this.IsTransitioning)
		{
			this.StopCoroutine(this.Transition);
		}
			this.Transition = this.StartCoroutine(this.Fade(0, duration, this.OnFadeOutStart, this.OnFadeOutEnd));
	}

	private void ChangeImageAlpha(float alpha)
	{
		this.Image.color = new Color(this.Image.color.r, this.Image.color.g, this.Image.color.b, alpha);
	}

	private IEnumerator Fade(float alpha, float duration, UnityEvent on_start, UnityEvent on_end)
	{
		on_start.Invoke();
		var start_time = Time.time;
		var start_alpha = this.Image.color.a;
		if (duration != 0)
		{
			for (float t = 0; t < 1; t = (Time.time - start_time) / duration)
			{
				this.ChangeImageAlpha(Mathf.Lerp(start_alpha, alpha, t));
				yield return null;
			}
		}
		this.ChangeImageAlpha(alpha);
		this.Transition = null;
		on_end.Invoke();
	}

	private void Awake()
	{
		this.Image = this.GetComponent<Image>();
	}

	private void Start()
	{
		if (this.ShouldStartFadedOut)
			this.FadeOut(0);
		else
			this.FadeIn(0);
	}
}
