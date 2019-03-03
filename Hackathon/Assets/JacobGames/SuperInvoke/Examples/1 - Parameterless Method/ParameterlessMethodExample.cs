using UnityEngine;
using JacobGames.SuperInvoke;
using UnityEngine.UI;

namespace JacobGames.SuperInvoke.Examples
{

		public class ParameterlessMethodExample : MonoBehaviour {

				public GameObject CubeGO;
				public Slider SliderInScene;

				private FigureMover cubeMover;


				private float Delay;	
				private bool TriggerMovement = false;


				void Awake () {
						cubeMover = CubeGO.GetComponent<FigureMover>();
				}



				void Update() {
						if(TriggerMovement) {  
								TriggerMovement = false;

								SuperInvoke.Run(moveCubeToRight, Delay); // Main line. Parameterless method execution delayed
						}

				}


				private void moveCubeToRight() {
						cubeMover.MoveTo(Direction.RIGHT);
				}





				public void TriggerCubeMovement() {
						Reset();
						this.Delay = SliderInScene.value;
						TriggerMovement = true;
				}



				private void Reset() {
						cubeMover.ReturnToInitialPosition();
						SuperInvoke.KillAll();
				}


		}

}
