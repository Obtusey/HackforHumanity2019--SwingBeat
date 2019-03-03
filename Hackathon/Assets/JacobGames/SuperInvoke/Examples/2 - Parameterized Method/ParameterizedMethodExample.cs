using UnityEngine;
using JacobGames.SuperInvoke;
using UnityEngine.UI;

namespace JacobGames.SuperInvoke.Examples 
{
		public class ParameterizedMethodExample : MonoBehaviour {

				public GameObject SphereGO;
				public Slider SliderInScene;

				private FigureMover sphereMover;

				private Direction myDirection;
				private float Delay;	

				private bool TriggerMovement = false;



				void Awake() {
						sphereMover = SphereGO.GetComponent<FigureMover>();
				}



				void Update() {
						if(TriggerMovement) { 
								TriggerMovement = false;

								SuperInvoke.Run(() => sphereMover.MoveTo(myDirection), Delay); // Main line. Parameterized method execution delayed.
						}
				}





				// Methods called by the UI buttons.
				public void MoveUp() {
						SetMovementParameters(Direction.UP);
				}

				public void MoveDown() {
						SetMovementParameters(Direction.DOWN);
				}

				public void MoveLeft() {
						SetMovementParameters(Direction.LEFT);
				}

				public void MoveRight() {
						SetMovementParameters(Direction.RIGHT);
				}





				private void SetMovementParameters(Direction direction) {
						Reset();
						myDirection = direction;
						Delay = SliderInScene.value;
						TriggerMovement = true;
				}




				private void Reset() {
						SuperInvoke.KillAll();
						sphereMover.ReturnToInitialPosition();
				}

		}

}


