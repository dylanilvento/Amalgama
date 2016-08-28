using UnityEngine;
using System.Collections;

public class CharacterInventory : MonoBehaviour {
	InventoryUpdater invUpdate;

	// Use this for initialization
	void Start () {
		invUpdate = GameObject.Find("Menu Object").GetComponent<InventoryUpdater>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.layer == 11) {
			// print("true");
			Element itemElement = other.gameObject.GetComponent<ElementController>().element;

			if (itemElement == Element.Cinnabar) {
				invUpdate.IncrementCinnabar();
			}

			else if (itemElement == Element.Sulfur) {

			}

			else if (itemElement == Element.Salt) {
				
			}

			else if (itemElement == Element.Stone) {
				
			}

			Destroy(other.gameObject);

		}
	}
}
