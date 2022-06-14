using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI{
	public class UIUtility : MonoBehaviour{
		[SerializeField] private float during = 1.5f;


		public void DoFadeOut(Image image){
			image.DOFade(1, 0f);
			image.DOFade(0, during)
					.OnComplete(() => image.gameObject.SetActive(false));
		}

		public void DoFadeIn(Image image){
			image.gameObject.SetActive(true);
			image.DOFade(0, 0f);
			image.DOFade(1, during);
		}
	}
}