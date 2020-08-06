using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] List<String> lines;
    [SerializeField] List<GameObject> leftPrefab;
    [SerializeField] List<GameObject> rightPrefab;

    public List<List<int>> GetLines() {
        List<List<int>> result = new List<List<int>>();
        foreach ( String element in lines) {
            List<int> temp = new List<int>();
            foreach ( char letter in element.ToCharArray()) {
                if (letter.Equals('+')) {
                    temp.Add(1);
                }
                else if (letter.Equals('-')) {
                    temp.Add(-1);
                }
                else if (letter.Equals('0')) {
                    temp.Add(0);
                }
                if (temp.Count == 10) {
                    break;
                }
            }
            result.Add(temp);
        }
        result.Reverse();
        return result;
    }

    public List<GameObject> GetLeftPrefabs() {
        return leftPrefab;
    }

    public List<GameObject> GetRightPrefabs() {
        return rightPrefab;
    }
}