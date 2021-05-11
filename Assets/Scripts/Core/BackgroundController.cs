
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {
	public static BackgroundController instance;
	public LAYER background = new LAYER();

	void Awake(){
		instance=this;
	}

	[System.Serializable]
	public class LAYER{
		public GameObject root;
		public GameObject newImageReference;
		public Image activeImage;
		public List<Image> imagenes = new List<Image>();

		public void setSprite(Sprite textura){
			if(textura != null){
				if(activeImage == null){
					createNewActiveImage();
				}
				activeImage.sprite = textura;
				//activeImage.color = GlobalF.SetAlpha(activeImage.color,1f);
			}else{
				if(activeImage != null){
					imagenes.Remove(activeImage);
					GameObject.DestroyImmediate(activeImage.gameObject);
					activeImage=null;
				}
			}
		}

		void createNewActiveImage(){
			GameObject ob = Instantiate(newImageReference,root.transform) as GameObject;
			ob.SetActive(true);
			Image img = ob.GetComponent<Image>();
			activeImage = img;
			imagenes.Add(img);

		}
	}
}

