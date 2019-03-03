using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace JacobGames.SuperInvoke.Examples
{
	
		public class RunRepeatExample : MonoBehaviour {


				public FigureMover cubeMover;

				public Slider SliderDelay;
				public Slider SliderRepeatRate;
				public Slider SliderRepeats;


				private float delay;
				private float repeatRate;	
				private int repeats;

	

				private bool TriggerPressed = false;

				public void TriggerCubeMovement() {						
						this.repeatRate = SliderRepeatRate.value;
						this.delay = SliderDelay.value;
						this.repeats = (int) SliderRepeats.value;

						if(TriggerPressed == false) {
								SuperInvoke.RunRepeat(delay, repeatRate, repeats, moveCubeToRight); 		
						}
						TriggerPressed = true;
				}


				private void moveCubeToRight() {
						cubeMover.ReturnToInitialPosition();
						cubeMover.MoveTo(Direction.RIGHT, repeatRate); //Same Repeat Rate to be synced with the movement and the repeat rate.
				}

		}


}

