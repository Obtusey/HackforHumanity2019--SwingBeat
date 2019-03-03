using UnityEngine;

namespace JacobGames.SuperInvoke.Examples
{

		public class FigureRotator : MonoBehaviour {

				private Quaternion initialRotation;

				void Awake() {
						initialRotation = this.transform.localRotation;
				}

				public void RotateZ(float angle) {
						Quaternion currentRotation = this.transform.localRotation;

						this.transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + angle);
				}

				public void ReturnToInitialRotation() {
						this.transform.localRotation = initialRotation;
				}
		}


}
