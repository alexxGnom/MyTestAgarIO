using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace MyAgarIO
{
	public class UIController : MonoBehaviour
	{

		[SerializeField]
		private Text playerScoreLabel;

		[SerializeField]
		private Unit player;

		void LateUpdate()
		{
			playerScoreLabel.text = String.Format("Score : {0}", player.Weight);
		}

	}
}
