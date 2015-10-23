using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Mehrhuhn baseHuhn;

    [System.Serializable]
	public class Spawninfo{
        public float scaling;
        public int points;
        public float spawnChancePerSecond;
        public Transform canvas;
        public int sortingOrder;
	}

	public Camera cam;
	public Rect LevelSize;

	public Spawninfo[] layer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float spawnvalue = Random.value;

        foreach (var spawn in layer)
        {
            float spawnvaluex = Random.value;
            float spawnvaluey = Random.value;
            if (spawnvalue <= spawn.spawnChancePerSecond)
            {
                GameObject go = GameObject.Instantiate<GameObject>(baseHuhn.gameObject);

                go.transform.SetParent(spawn.canvas);
                go.transform.position = new Vector3(LevelSize.width * spawnvaluex + LevelSize.x + transform.position.x,
                    LevelSize.height * spawnvaluey + LevelSize.y + transform.position.y, 0);

                var spriteRender = go.GetComponent<SpriteRenderer>();
                spriteRender.sortingOrder = spawn.sortingOrder;
            }
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + new Vector3(LevelSize.x + LevelSize.width/2, LevelSize.y + LevelSize.height/2)
            , new Vector3(LevelSize.width, LevelSize.height, 0));
    }
}
