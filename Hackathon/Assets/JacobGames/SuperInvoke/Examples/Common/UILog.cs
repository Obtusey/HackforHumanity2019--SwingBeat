using UnityEngine;
using UnityEngine.UI;

namespace JacobGames.SuperInvoke.Examples
{
		public class UILog : MonoBehaviour {

				public GameObject Log1;
				public GameObject Log2;
				public Slider SliderInScene;

				public Text DirectionText;
				public Text DelayText;


				private float timer;
				private bool triggerTimer = false;



				void FixedUpdate() {
						if(triggerTimer) {

								timer -= Time.deltaTime;
								DelayText.text = timer.ToString("F2");


								if(timer <= 0) {
										triggerTimer = false;

										DelayText.text = "0";
										Log1.SetActive(false);
										Log2.SetActive(true);
								}
						}

				}



				public void StartUILog() {
						Log1.SetActive(true);
						Log2.SetActive(false);

						timer = SliderInScene.value;
						triggerTimer = true;
				}






				#region Methods called by buttons
				public void DirectionUp() {
						DirectionText.text = Direction.UP.ToString();
						StartUILog();
				}

				public void DirectionDown() {
						DirectionText.text = Direction.DOWN.ToString();
						StartUILog();
				}

				public void DirectionRight() {
						DirectionText.text = Direction.RIGHT.ToString();
						StartUILog();
				}

				public void DirectionLeft() {
						DirectionText.text = Direction.LEFT.ToString();
						StartUILog();
				}
				#endregion
		}

		
}

