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
		public Vector2 targetHight;
	}

	public Camera cam;
	public Rect LevelSize;

	public Spawninfo[] layer;

	private float spawntick = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		spawntick -= Time.deltaTime;

		if (spawntick > 0)
			return;


        float spawnvalue = Random.value;
		spawntick = 1;

        foreach (var spawn in layer)
        {
            float spawnvaluex = Random.value;
            float spawnvaluey = Random.value;
			float direction = Random.value-0.5f; // <0  go Left spawn Right ; >0 go Rigth spawn Left
            if (spawnvalue <= spawn.spawnChancePerSecond)
            {
                GameObject go = GameObject.Instantiate<GameObject>(baseHuhn.gameObject);
				go.transform.SetParent(spawn.canvas);
				go.transform.localScale *= spawn.scaling;

				var targeth = (spawn.targetHight.y-spawn.targetHight.x)*spawnvaluey+spawn.targetHight.x+ transform.position.y;
				var spriteRender = go.GetComponent<SpriteRenderer>();
				spriteRender.sortingOrder = spawn.sortingOrder;
				
				
				var mehrhuhn = go.GetComponent<Mehrhuhn>();
				mehrhuhn.targetHeight = targeth;

				mehrhuhn.goXPositiv = direction > 0f;
				mehrhuhn.points = spawn.points;
				mehrhuhn.maxX = transform.position.x + LevelSize.width;


				//out of screen spawn
				if(Random.value >= 0.5){
					if(direction < 0){
						go.transform.position = new Vector3(LevelSize.width  + LevelSize.x + transform.position.x,targeth, 0);
					} else{
						go.transform.position = new Vector3(LevelSize.x + transform.position.x - 3 ,targeth, 0);
					}					
				} else{
					go.transform.position = new Vector3(LevelSize.width*spawnvaluex + LevelSize.x + transform.position.x,LevelSize.y + transform.position.y, 0);
				}

				mehrhuhn.lifeTime = Random.Range(10,100);
				go.SetActive(true);
				
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
