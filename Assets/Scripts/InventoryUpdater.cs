using UnityEngine;
using System.Collections;

public class InventoryUpdater : MonoBehaviour {

	public Sprite[] nums = new Sprite[10];

	int cinnabarCnt = 0;
	int sulfurCnt = 0;
	int saltCnt = 0;
	int stoneCnt = 0;

	//0 is tens place, 1 is ones place
	public SpriteRenderer[] cinnabarNums = new SpriteRenderer[2];
	public SpriteRenderer[] sulfurNums = new SpriteRenderer[2];
	public SpriteRenderer[] saltNums = new SpriteRenderer[2];
	public SpriteRenderer[] stoneNums = new SpriteRenderer[2];


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementCinnabar () {
		if (cinnabarCnt >= 99) {
			cinnabarNums[0].sprite = nums[9];
			cinnabarNums[1].sprite = nums[9];
		}
		else {
			cinnabarCnt++;

			print(cinnabarCnt % 10);
			cinnabarNums[0].sprite = nums[cinnabarCnt / 10];
			cinnabarNums[1].sprite = nums[cinnabarCnt % 10];
		}
		

	}

}
