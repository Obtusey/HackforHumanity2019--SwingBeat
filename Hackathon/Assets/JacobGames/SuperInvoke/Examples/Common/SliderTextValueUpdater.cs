using UnityEngine;
using UnityEngine.UI;

namespace JacobGames.SuperInvoke.Examples 
{

		public class SliderTextValueUpdater : MonoBehaviour {

				public Slider DelaySlider;
				private Text text;

				public bool isWholeNumber;

				void Awake () {
						text = GetComponent<Text>();
						if(isWholeNumber) {
								text.text = DelaySlider.value.ToString();
						} else {
								text.text = DelaySlider.value.ToString("F2");		
						}

				}


				public void UpdateValue(float value) {
						if(isWholeNumber) {
								text.text = DelaySlider.value.ToString();
						} else {
								text.text = DelaySlider.value.ToString("F2");		
						}
				}

		}

}


