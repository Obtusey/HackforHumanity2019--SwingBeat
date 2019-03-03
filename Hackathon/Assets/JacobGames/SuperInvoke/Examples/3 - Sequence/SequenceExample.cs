using UnityEngine;
using System.Collections;
using JacobGames.SuperInvoke;
using UnityEngine.UI;

namespace JacobGames.SuperInvoke.Examples {
	
	
		public class SequenceExample : MonoBehaviour {

				public GameObject Bomb;
				public Slider SliderInScene;

				private ISuperInvokeSequence sequence;

				private FigureMover bombMover;
				private FigureScaler bombScaler;
				private FigureRotator bombRotator;

				private ParticleSystem explosion;

				float movementDuration;


				void Awake() {
						bombMover = Bomb.GetComponent<FigureMover>();
						bombScaler = Bomb.GetComponent<FigureScaler>();
						bombRotator = Bomb.GetComponent<FigureRotator>();

						explosion = Bomb.GetComponentInChildren<ParticleSystem>();
				}




				private void ComposeSequence() {
						sequence = SuperInvoke.CreateSequence();
						movementDuration = SliderInScene.value / 2f; // 2 movements of equal duration

						sequence.AddMethod(()=> bombMover.MoveTo(new Vector2(0, 2.2f), movementDuration)); // move up
						sequence.AddDelay(movementDuration);

						// after the previous delay, rotate and move to right and down
						sequence.AddMethod(()=> bombRotator.RotateZ(20f)); 
						sequence.AddMethod(()=> bombMover.MoveTo(new Vector2(4.5f, -0.5f), movementDuration));
						sequence.AddDelay(movementDuration);

						// at the end, bomb explodes
						sequence.AddMethod(()=> bombScaler.Scale(0));
						sequence.AddMethod(()=> explosion.Play());
				}





				// Called by button in scene
				public void RunBombSequence() {
						Reset();
						ComposeSequence();
						sequence.Run("seq");
			
				}




				private void Reset() {
						SuperInvoke.Kill("seq");					
						bombMover.ReturnToInitialPosition();	
						bombScaler.ReturnToInitialScale();
						bombRotator.ReturnToInitialRotation();
				}


		}
}


