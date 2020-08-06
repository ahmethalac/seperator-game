using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] int initialLeft;
    [SerializeField] int leftCorrect;
    [SerializeField] int leftFalse;

    [SerializeField] int initialRight;
    [SerializeField] int rightCorrect;
    [SerializeField] int rightFalse;

    [SerializeField] List<LevelConfig> levels;

    [SerializeField][Range(0,10)] float conveyorSpeed;
    [SerializeField] private float startPoint = 14;

    [SerializeField] float cameraSpeed;
    Camera myCamera;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(StartGame());
        myCamera = Camera.main;
        StartCoroutine(CameraMove());
    }

    public IEnumerator StartGame() {
        yield return new WaitForSeconds(1.5f);
        LoadLevel(levels[0]);
    }

    public IEnumerator CameraMove() {
        while (myCamera.transform.position.x < -6) {
            myCamera.transform.position += new Vector3(cameraSpeed * Time.deltaTime,0,0);
            myCamera.transform.Rotate(Vector3.right,cameraSpeed * Time.deltaTime * 1.5f);
            yield return new WaitForEndOfFrame();
        }
    }

    private void LoadLevel(LevelConfig levelConfig) {
        leftCorrect = 0;
        rightCorrect = 0;
        leftFalse = 0;
        rightFalse = 0;
        initialLeft = 0;
        initialRight = 0;

        StartCoroutine(CreateBoxes(levelConfig.GetLeftPrefabs(),
                                   levelConfig.GetRightPrefabs(),
                                   levelConfig.GetLines()));
    }

    public void Restart() {
        LoadLevel(levels[0]);
    }
    private IEnumerator CreateBoxes(List<GameObject> leftPrefab,List<GameObject> rightPrefab,List<List<int>> lines) {
        foreach(List<int> line in lines) {
            float z = 2.25f;
            foreach(int temp in line) {
                if(temp == 1) {
                    var prefab = leftPrefab[Random.Range(0,leftPrefab.Count)];
                    var obj = Instantiate(prefab,
                                new Vector3(Random.Range(startPoint - 0.2f,startPoint + 0.2f),0,Random.Range(z - 0.1f,z + 0.1f)),
                                prefab.transform.rotation);
                    obj.transform.GetChild(0).gameObject.tag = "Left";
                    obj.GetComponentInChildren<Food>().BackVelocity(conveyorSpeed);
                    initialLeft++;
                }
                else if (temp == -1) {
                    var prefab = rightPrefab[Random.Range(0,rightPrefab.Count)];
                    var obj = Instantiate(prefab,
                                new Vector3(Random.Range(startPoint - 0.2f,startPoint + 0.2f),0,Random.Range(z - 0.1f,z + 0.1f)),
                                prefab.transform.rotation);
                    obj.transform.GetChild(0).gameObject.tag = "Right";
                    obj.GetComponentInChildren<Food>().BackVelocity(conveyorSpeed);
                    initialRight++;
                }
                z -= 0.5f;
            }
            yield return new WaitForSeconds(1 / conveyorSpeed);           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CorrectLeft() {
        leftCorrect++;
    }

    public void CorrectRight() {
        rightCorrect++;
    }

    public void FalseLeft() {
        leftFalse++;
    }

    public void FalseRight() {
        rightFalse++;
    }

    public float GetStartPoint() {
        return startPoint;
    }

    public float GetConveyorSpeed() {
        return conveyorSpeed;
    }
}
