using UnityEngine;

namespace JacobGames.SuperInvoke.Examples
{
		
		public class FigureScaler : MonoBehaviour {

				private Vector3 initialScale;

				void Awake() {
						initialScale = this.transform.localScale;
				}

				public void Scale(float factor) {
						Scale (new Vector3(factor, factor, factor));        
				}

				public void Scale(Vector3 factor) {
						this.transform.localScale = factor;
				}

				public void ReturnToInitialScale() {
						this.transform.localScale = initialScale;
				}
		}

}

